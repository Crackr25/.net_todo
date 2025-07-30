using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;

        public async Task<IActionResult> Index(string? category = null, string? search = null)
        {
            var userId = GetUserId();
            IEnumerable<TodoItem> todos;

            if (!string.IsNullOrEmpty(search))
            {
                todos = await _todoService.SearchUserTodosAsync(userId, search);
            }
            else if (!string.IsNullOrEmpty(category))
            {
                todos = await _todoService.GetUserTodosByCategoryAsync(userId, category);
            }
            else
            {
                todos = await _todoService.GetUserTodosAsync(userId);
            }

            ViewBag.Categories = await _todoService.GetUserCategoriesAsync(userId);
            ViewBag.Statistics = await _todoService.GetTodoStatisticsAsync(userId);
            ViewBag.CurrentCategory = category;
            ViewBag.SearchTerm = search;

            return View(todos);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _todoService.GetUserCategoriesAsync(GetUserId());
            return View(new TodoItem());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                todo.UserId = GetUserId();
                await _todoService.CreateTodoAsync(todo);
                TempData["Success"] = "Todo created successfully!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = await _todoService.GetUserCategoriesAsync(GetUserId());
            return View(todo);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id, GetUserId());
            if (todo == null)
            {
                return NotFound();
            }

            ViewBag.Categories = await _todoService.GetUserCategoriesAsync(GetUserId());
            return View(todo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TodoItem todo)
        {
            if (id != todo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingTodo = await _todoService.GetTodoByIdAsync(id, GetUserId());
                if (existingTodo == null)
                {
                    return NotFound();
                }

                existingTodo.Title = todo.Title;
                existingTodo.Description = todo.Description;
                existingTodo.Category = todo.Category;
                existingTodo.Priority = todo.Priority;
                existingTodo.DueDate = todo.DueDate;

                await _todoService.UpdateTodoAsync(existingTodo);
                TempData["Success"] = "Todo updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = await _todoService.GetUserCategoriesAsync(GetUserId());
            return View(todo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _todoService.DeleteTodoAsync(id, GetUserId());
            if (success)
            {
                TempData["Success"] = "Todo deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Todo not found or could not be deleted.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Toggle(int id)
        {
            var success = await _todoService.ToggleCompletionAsync(id, GetUserId());
            if (!success)
            {
                TempData["Error"] = "Todo not found.";
            }
            return RedirectToAction(nameof(Index));
        }

        // API Endpoints for AJAX calls
        [HttpPost]
        public async Task<IActionResult> ToggleAjax(int id)
        {
            var success = await _todoService.ToggleCompletionAsync(id, GetUserId());
            return Json(new { success });
        }

        [HttpGet]
        public async Task<IActionResult> GetStatistics()
        {
            var stats = await _todoService.GetTodoStatisticsAsync(GetUserId());
            return Json(stats);
        }
    }
}

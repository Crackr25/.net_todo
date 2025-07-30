using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly ApplicationDbContext _context;

        public TodoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetUserTodosAsync(string userId)
        {
            return await _context.TodoItems
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.Priority)
                .ThenBy(t => t.DueDate)
                .ThenByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetUserTodosByCategoryAsync(string userId, string category)
        {
            return await _context.TodoItems
                .Where(t => t.UserId == userId && t.Category == category)
                .OrderByDescending(t => t.Priority)
                .ThenBy(t => t.DueDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<TodoItem>> SearchUserTodosAsync(string userId, string searchTerm)
        {
            return await _context.TodoItems
                .Where(t => t.UserId == userId && 
                           (t.Title.Contains(searchTerm) || 
                            (t.Description != null && t.Description.Contains(searchTerm))))
                .OrderByDescending(t => t.Priority)
                .ThenBy(t => t.DueDate)
                .ToListAsync();
        }

        public async Task<TodoItem?> GetTodoByIdAsync(int id, string userId)
        {
            return await _context.TodoItems
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        }

        public async Task<TodoItem> CreateTodoAsync(TodoItem todo)
        {
            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<TodoItem> UpdateTodoAsync(TodoItem todo)
        {
            _context.TodoItems.Update(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> DeleteTodoAsync(int id, string userId)
        {
            var todo = await GetTodoByIdAsync(id, userId);
            if (todo == null) return false;

            _context.TodoItems.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ToggleCompletionAsync(int id, string userId)
        {
            var todo = await GetTodoByIdAsync(id, userId);
            if (todo == null) return false;

            todo.IsCompleted = !todo.IsCompleted;
            todo.CompletedAt = todo.IsCompleted ? DateTime.UtcNow : null;
            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<string>> GetUserCategoriesAsync(string userId)
        {
            return await _context.TodoItems
                .Where(t => t.UserId == userId)
                .Select(t => t.Category)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetTodoStatisticsAsync(string userId)
        {
            var todos = await _context.TodoItems
                .Where(t => t.UserId == userId)
                .ToListAsync();

            return new Dictionary<string, int>
            {
                ["Total"] = todos.Count,
                ["Completed"] = todos.Count(t => t.IsCompleted),
                ["Pending"] = todos.Count(t => !t.IsCompleted),
                ["Overdue"] = todos.Count(t => !t.IsCompleted && t.DueDate.HasValue && t.DueDate < DateTime.Today),
                ["High Priority"] = todos.Count(t => !t.IsCompleted && t.Priority >= Priority.High)
            };
        }
    }
}

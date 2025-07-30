using TodoApp.Models;

namespace TodoApp.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetUserTodosAsync(string userId);
        Task<IEnumerable<TodoItem>> GetUserTodosByCategoryAsync(string userId, string category);
        Task<IEnumerable<TodoItem>> SearchUserTodosAsync(string userId, string searchTerm);
        Task<TodoItem?> GetTodoByIdAsync(int id, string userId);
        Task<TodoItem> CreateTodoAsync(TodoItem todo);
        Task<TodoItem> UpdateTodoAsync(TodoItem todo);
        Task<bool> DeleteTodoAsync(int id, string userId);
        Task<bool> ToggleCompletionAsync(int id, string userId);
        Task<IEnumerable<string>> GetUserCategoriesAsync(string userId);
        Task<Dictionary<string, int>> GetTodoStatisticsAsync(string userId);
    }
}

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TodoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }
        
        public bool IsCompleted { get; set; }
        
        public Priority Priority { get; set; } = Priority.Medium;
        
        [Required]
        public string Category { get; set; } = "General";
        
        public DateTime? DueDate { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? CompletedAt { get; set; }
        
        // User association
        public string UserId { get; set; } = string.Empty;
        public virtual IdentityUser? User { get; set; }
    }
    
    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3,
        Urgent = 4
    }
}

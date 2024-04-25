using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TaskAPI.Entities
{
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; } = string.Empty;

        [Required]
        public string Day { get; set; } = string.Empty;

        [Required]
        public bool Reminder { get; set; } = false;
    }
    
 
}

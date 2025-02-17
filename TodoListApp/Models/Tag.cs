using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TodoListApp.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        
        [Required]
        public string TagName { get; set; } = string.Empty; // "Home","Work", "Shop"
        public List<Project> Projects { get; set; } = new();
    }

}


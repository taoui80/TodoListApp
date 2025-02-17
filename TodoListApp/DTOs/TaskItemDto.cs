using System;
using System.ComponentModel.DataAnnotations;
using TodoListApp.Models;

namespace TodoListApp.DTOs
{
   public class TaskItemDto
   {
        //[Required]
        //public int TaskId { get; set; }

        [Required] 
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime DueDate { get; set;} = DateTime.Now.AddDays(7);
    
        [Required]
        public TaskItemStatus Status { get; set;} = TaskItemStatus.Pending; // Default status
        
        //[Required]
        //public int ProjectId { get; set; }  
    }       
   
} 



using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TodoListApp.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set;}
    
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set;} = string.Empty;
      
        [Required(ErrorMessage = "Please enter a due date")]
        public DateTime DueDate { get; set;} = DateTime.Now.AddDays(7);
    
        [Required]
        public TaskItemStatus Status { get; set;} = TaskItemStatus.Pending; // Default status
    
        [Required]
        public int ProjectId { get; set;} //FK 
        [ForeignKey("ProjectId")]
        
        //[JsonIgnore]
        public Project? Project { get; set;} //= null!; 

        public void InProgress() => Status = TaskItemStatus.InProgress; 
        public void Done() => Status = TaskItemStatus.Done;  
      
    }
}



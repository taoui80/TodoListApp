using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TodoListApp.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
    
        [Required(ErrorMessage = "Please enter a project name")]    
        public string ProjectName { get; set; } = string.Empty;
    
        [Required(ErrorMessage = "Please enter a tag")]
        public int TagId { get; set; }  //FK to Tag
    
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }  = null!; // Work, Home, Shop

        [Required(ErrorMessage = "Please enter a status")]
        public ProjectStatus Status { get; set; } = ProjectStatus.Pending; //FK
    
        //[JsonIgnore]
        public List<TaskItem> TaskItems { get; set; } = new(); // One to Many

        public void Pause() => Status = ProjectStatus.Pending;
        public void Active() => Status = ProjectStatus.Active; 
        public void Completed() => Status = ProjectStatus.Completed;  

    }
}


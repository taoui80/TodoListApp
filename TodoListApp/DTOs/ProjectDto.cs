using System;
using System.ComponentModel.DataAnnotations;
using TodoListApp.Models;

namespace TodoListApp.Dtos
{
    public class ProjectDto
    {
    
    [Required]
    public string ProjectName { get; set; } = string.Empty;

    [Required]
    public int TagId { get; set; } // Only send TagId, not the full Tag object
    
    [Required]
    public ProjectStatus Status { get; set; } = ProjectStatus.Pending;
    }
}


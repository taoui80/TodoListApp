using System;
using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Models;

public class Project
{
    [Key]
    public int Id { get; set;}
    public string? ProjectName { get; set;}

    public Project() {}
    public Project(int id, string projectName)
    {
        Id = id;
        ProjectName = projectName;
    }

}

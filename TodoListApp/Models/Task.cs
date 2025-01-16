using System;

namespace TodoListApp.Models;
public class Task
{
    public int Id { get; set;}
    public string? TaskName { get; set;}

    public Task() {}
    public Task(int id, string taskName)
    {
        Id = id;
        TaskName = taskName;
    }

}

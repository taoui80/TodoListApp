using System;

namespace TodoListApp.Models;

public class Tag
{
    public int Id { get; set;}
    public string? TagName { get; set;}

    public Tag() {}
    public Tag(int id, string tagName)
    {
        Id = id;
        TagName = tagName; 
    }
}

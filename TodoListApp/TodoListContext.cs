using System;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Models;

namespace TodoListApp;

public class TodoListContext : DbContext
{
    public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
    {
    }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    public DbSet<Tag> Tags { get; set; }

}

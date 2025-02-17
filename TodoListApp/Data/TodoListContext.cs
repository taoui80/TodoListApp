using Microsoft.EntityFrameworkCore;
using TodoListApp.Models;

namespace TodoListApp.Data
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options) {}
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<TaskItem> TaskItems { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(
                new Tag { TagId = 1, TagName = "Home" },
                new Tag { TagId = 2, TagName = "Work"},
                new Tag { TagId = 3, TagName = "Shop"}
            );
            
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Project)
                .WithMany(p => p.TaskItems)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Tag)
                .WithMany(t => t.Projects)
                .HasForeignKey(p => p.TagId)
                .OnDelete(DeleteBehavior.Restrict);    
        }
    }
}


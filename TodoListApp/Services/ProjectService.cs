using Microsoft.EntityFrameworkCore;
using TodoListApp.Models;

namespace TodoListApp.Services
{
    /*
    public class ProjectService : IProjectService
    {
        private readonly TodoListContext _contextDb;
        public ProjectService(TodoListContext contextDb) 
        {
             _contextDb = contextDb;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _contextDb
                .Projects
                .Include(p => p.Tag)
                .Include(p => p.Status)
                .Include(p => p.TaskItems)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectsByTagAsync(string tagName)
        {
            return await _contextDb
                .Projects
                .Include(p => p.Tag)
                .Where(p => p.Tag.TagName == tagName)
                .ToListAsync();
        }   
        public async Task<Project?> GetProjectByIdAsync(int projectId)
        {
            var project = await _contextDb
                .Projects
                .Include(p => p.Tag)
                .Include(p => p.TaskItems)
                .FirstOrDefaultAsync(p => p.ProjectId == projectId); 
        
            return project ?? throw new KeyNotFoundException($"Project with ID {projectId} not found.");       
        }
    
        public async Task<Project> CreateProjectAsync(Project project)
        {
            var tag = await _contextDb.Tags.FindAsync(project.TagId);
            if(tag == null) 
            {
                throw new ArgumentException("Invalid Tag");
            }

            _contextDb.Projects.Add(project);
            await _contextDb.SaveChangesAsync();
            return project;   
        }
    
        public async Task<Project?> UpdateProjectStatusAsync(int projectId, ProjectStatus status)
        {
            var project = await _contextDb.Projects.FindAsync(projectId);
            if(project == null) return null;
        
            project.Status = status;
            await _contextDb.SaveChangesAsync();
            return project;  
        }

        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            var project = await _contextDb.Projects.FindAsync(projectId);
            if(project == null) return false;

            _contextDb.Projects.Remove(project);
            await _contextDb.SaveChangesAsync();
            return true;
        }
/*
        public async Task<Project?> PauseProjectAsync(int projectId)
        {
            var project = await _contextDb.Projects.FindAsync(projectId);
            if(project == null) return null;
        
            project.Pause();
            await _contextDb.SaveChangesAsync();
            return project;  
        }

        public async Task<Project?> ActivateProjectAsync(int projectId)
        {
            var project = await _contextDb.Projects.FindAsync(projectId);
            if(project == null) return null;
        
            project.Active();
            await _contextDb.SaveChangesAsync();
            return project;  
        } 
    } */
}




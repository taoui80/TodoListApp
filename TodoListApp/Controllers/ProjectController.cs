using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Data;
using TodoListApp.Dtos;
using TodoListApp.Models;


namespace TodoListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {   
		private readonly TodoListContext _contextDb;
        public ProjectController(TodoListContext contextDb) 
        {
             _contextDb = contextDb;
        }

		[HttpGet("read")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _contextDb
			.Projects
			//.Include(p => p.TagId)
            //.Include(p => p.Status)
            .Include(p => p.TaskItems)
			.ToListAsync();
        }
/*
		// Get projects filtered by a specific tag
		[HttpGet("filter-by-tag/{tagName}")]
		public async Task<ActionResult<IEnumerable<Project>>> GetProjectsByTag(string tagName)
		{
			return await _contextDb
			   	.Projects
                .Include(p => p.Tag)
                .Where(p => p.Tag.TagName == tagName)
				.Include(p => p.Status)
            	.Include(p => p.TaskItems)
                .ToListAsync();
		}*/
		
		// Get project by Id
		[HttpGet("{projectId}")]
		public async Task<IActionResult> GetProjectById(int projectId)
		{
			var project = await _contextDb
				.Projects
                //.Include(p => p.Tag)
				//.Include(p => p.Status)
                //Include(p => p.TaskItems)
				//.FindAsync(projectId);
                .FirstOrDefaultAsync(p => p.ProjectId == projectId); 
        	
			return project == null ? NotFound() : Ok(project) ;
			
			
            
			//(IActionResult)(project ?? throw new KeyNotFoundException($"Project with ID {ProjectId} not found.")); 
			
		} 

		// Create
	    [HttpPost("create")]
	    public async Task<IActionResult> CreateProject([FromBody] ProjectDto dto)
	    {
			if (!ModelState.IsValid)
				return BadRequest("ModelState");
			
			var project = new Project
			{
				ProjectName = dto.ProjectName,
				TagId = dto.TagId,
				Status = dto.Status = ProjectStatus.Pending // Default status
			};
			
			_contextDb.Projects.Add(project);
            await _contextDb.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProjects), new {id = project.ProjectId}, project );   	
	    }
		
		// Update project
		[HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(int projectId, [FromBody] ProjectDto dto)
		{
			if (!ModelState.IsValid) return BadRequest("ModelState");

			var project = await _contextDb.Projects.FindAsync(projectId);
            if(project == null) return NotFound(project);

			project.ProjectName = dto.ProjectName;
			project.TagId = dto.TagId;
            project.Status = dto.Status = ProjectStatus.Pending; // Default status

			_contextDb.Projects.Update(project);
            await _contextDb.SaveChangesAsync();
            return  Ok(project);
			
		}

		 // Delete
	   	[HttpDelete("{projectId}")]
	    public async Task<IActionResult> DeleteProject(int projectId)
		{
			var project = await _contextDb.Projects.FindAsync(projectId);
			if (project == null)
			{
				return NotFound();
			}
			_contextDb.Projects.Remove(project);
			await _contextDb.SaveChangesAsync();
			return Ok("deleted task");
		}	

        // Pause project
		[HttpPut("{projectId}/pause")]
		public async Task<IActionResult> PauseProject(int projectId)
		{
			var project = await _contextDb.Projects.FindAsync(projectId);
            if(project == null) return NotFound();
        
            project.Pause();
            await _contextDb.SaveChangesAsync();
            return Ok(project);  	
		}

		// Activate project
		[HttpPut("{projectId}/activate")]
		public async Task<IActionResult> ActivateProject(int projectId)
		{
			var project = await _contextDb.Projects.FindAsync(projectId);
            if(project == null) return NotFound();
        
            project.Active();
            await _contextDb.SaveChangesAsync();
            return Ok(project);  
		} 

		// Complete project
		[HttpPut("{projectId}/complete")]
		public async Task<IActionResult> CompleteProject(int projectId)
		{
			var project = await _contextDb.Projects.FindAsync(projectId);
            if(project == null) return NotFound();
        
            project.Completed();
            await _contextDb.SaveChangesAsync();
            return Ok(project);  
		}
	   				
	}	    	   
}

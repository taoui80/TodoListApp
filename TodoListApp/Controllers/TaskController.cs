using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Data;
using TodoListApp.DTOs;
using TodoListApp.Models;
using TodoListApp.Services;
using TaskItemStatus = TodoListApp.Models.TaskItemStatus;

namespace TodoListApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
		private readonly TodoListContext _contextDb;
		public TaskController(TodoListContext contextDb) 
        {
             _contextDb = contextDb;
        }
               
		// Read
        [HttpGet("read")]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
		{	
            return await _contextDb.TaskItems.ToListAsync();
		}
		
        // Create
		[HttpPost("create")]
	    public async Task<IActionResult> CreateTask(int projectId, [FromBody] TaskItemDto dto)
		{	
			if (!ModelState.IsValid)
				return BadRequest("ModelState");
			
			var project = await _contextDb.Projects.FindAsync(projectId);
            if (project == null) return NotFound("Project not found");	
			
			var taskItem = new TaskItem
			{
				Description = dto.Description,
				DueDate = dto.DueDate,
				Status = dto.Status = TaskItemStatus.Pending, // Default status
				ProjectId = projectId
			};
			
            _contextDb.TaskItems.Add(taskItem);
            await _contextDb.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTasks), new {id = taskItem.TaskId}, taskItem);   		
		}	
		
		// Get Task by Id
		[HttpGet("{taskId}")]
		public async Task<IActionResult> GetTaskById(int taskId)
		{
			var taskItem = await _contextDb.TaskItems.FindAsync(taskId);
			return taskItem == null ? NotFound("Task not found") : Ok(taskItem);
		} 
			

        // Update
		[HttpPut("{taskId}")]
        public async Task<IActionResult> UpdateTask(int taskId, [FromBody] TaskItemDto dto)
		{
			if (!ModelState.IsValid) return BadRequest("ModelState");

			var taskItem = await _contextDb.TaskItems.FindAsync(taskId);
            if(taskItem == null) return NotFound("taskItem not found");

			taskItem.Description = dto.Description;
			taskItem.DueDate = dto.DueDate;
            taskItem.Status = dto.Status = TaskItemStatus.Pending;
            
			_contextDb.TaskItems.Update(taskItem);
            await _contextDb.SaveChangesAsync();
            return  Ok("Task updated");
		}	

	    // Delete
		[HttpDelete("{taskId}")]
		public async Task<IActionResult> DeleteTask(int taskId)
		{
			var taskItem = await _contextDb.TaskItems.FindAsync(taskId);
			if (taskItem == null) 
			{
				return NotFound("Task not found");
			}
			_contextDb.TaskItems.Remove(taskItem);
			await _contextDb.SaveChangesAsync();

			return Ok("Task deleted");
		}

		// Task InProgress
		[HttpPut("{taskId}/inProgress")]
		public async Task<IActionResult> TaskInProgress(int taskId)
		{
			var taskItem = await _contextDb.TaskItems.FindAsync(taskId);
            if(taskItem == null) return NotFound("TaskItem not found");
        
            taskItem.InProgress();
            await _contextDb.SaveChangesAsync();
            return Ok(taskItem);  
		} 

		// Task Done
		[HttpPut("{taskId}/done")]
		public async Task<IActionResult> TaskDone(int taskId)
		{
			var taskItem = await _contextDb.TaskItems.FindAsync(taskId);
            if(taskItem == null) return NotFound(taskItem);
        
            taskItem.Done();
            await _contextDb.SaveChangesAsync();
            return Ok(taskItem);  
		}		

	}
}

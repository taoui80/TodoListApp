using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        
        private readonly TodoListContext _taskDb;
        public TaskController(TodoListContext taskDb)
        {
            _taskDb = taskDb;
        }
        
        // Create
	    [HttpPost("create")]
	    public bool Index(Models.Task task)
	    {
		    _taskDb.Tasks.Add(task);  
		    _taskDb.SaveChanges();
		    return true;
	    }
		
        // Read
        [HttpGet("read")]
        public List<Models.Task> Index()
        {
            return _taskDb.Tasks.ToList();
        }

        // Update
		[HttpPost("update")]
        public bool UpdateTask(int id, Models.Task updatedTask)
	    {
		    var task = _taskDb.Tasks.FirstOrDefault(t => t.Id == id);
		    if (task != null)
		    {
			    task.TaskName = updatedTask.TaskName;
			    _taskDb.SaveChanges();
			    return true;
		    }
		    return false;		
	    }

	    // Delete
		[HttpGet("delete")]
		public bool DeleteTask(int id)
		{
			var task = _taskDb.Tags.FirstOrDefault(p => p.Id == id);
			if (task == null)
			{
				return false;
			}
				_taskDb.Tags.Remove(task);
				return _taskDb.SaveChanges() > 0;
		}
    }
}

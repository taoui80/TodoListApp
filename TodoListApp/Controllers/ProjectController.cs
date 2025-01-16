using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;

namespace TodoListApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {   
        private readonly TodoListContext _projectDb;
        public ProjectController(TodoListContext projectDb)
        {
            _projectDb = projectDb;
        }
        
        // Create
	    [HttpPost("create")]
	    public bool Index(Project project)
	    {
		_projectDb.Projects.Add(project);
		_projectDb.SaveChanges();
		return true;
	    }

        // Read
        [HttpGet("read")]
        public List<Project> Index()
        {
            return _projectDb.Projects.ToList();
        }

        // Update
	    [HttpPost("update")]
        public bool UpdateProject(int id, Project updatedProject)
	    {
		    var project = _projectDb.Projects.FirstOrDefault(p => p.Id == id);
		    if (project != null)
		    {
			    project.ProjectName = updatedProject.ProjectName;
			    _projectDb.SaveChanges();
			    return true;
		    }
		    return false;		
	    }

	    // Delete
	   	[HttpGet("delete")]
	    public bool DeleteProject(int id)
		{
			var project = _projectDb.Projects.FirstOrDefault(p => p.Id == id);
			if (project == null)
			{
				return false;
			}
				_projectDb.Projects.Remove(project);
				return _projectDb.SaveChanges() > 0;
		}					
	}	    	   
}

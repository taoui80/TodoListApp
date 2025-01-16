using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;

namespace TodoListApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {  
        private readonly TodoListContext _tagDb;
        public TagController(TodoListContext tagDb)
        {
            _tagDb = tagDb;
        }
    
        // Create
	    [HttpPost("create")]
	    public bool Index(Tag tag)
	    {
		    _tagDb.Tags.Add(tag);  
		    _tagDb.SaveChanges();
		    return true;
	    }

        // Read
        [HttpGet("read")]
        public List<Tag> Index()
        {
            return _tagDb.Tags.ToList();
        }

        // Update
	    [HttpPost("update")]
        public bool UpdateTag(int id, Tag updatedTag)
	    {
		    var tag = _tagDb.Tags.FirstOrDefault(t => t.Id == id);
		    if (tag != null)
		    {
			    tag.TagName = updatedTag.TagName;
			    _tagDb.SaveChanges();
			    return true;
		    }
		    return false;		
	    }

	    // Delete
		[HttpGet("delete")]
		public bool DeleteTag(int id)
		{
			var tag = _tagDb.Tags.FirstOrDefault(p => p.Id == id);
			if (tag == null)
			{
				return false;
			}
				_tagDb.Tags.Remove(tag);
				return _tagDb.SaveChanges() > 0;
		}
    }
}

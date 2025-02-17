namespace TodoListApp.Services
{ /*
    public class TaskItemService : ITaskItemService
    {
        private readonly TodoListContext _contextDb;
        public TaskItemService(TodoListContext contextDb)
        {
            _contextDb = contextDb;
        }

       public async Task<IEnumerable<TaskItem>> GetTasksAsync()
       {
            return await _contextDb
                .TaskItems
                .Include(t => t.ProjectId)
                .Include(t => t.Status)
                .Include(t => t.DueDate)
                .ToListAsync();
        } 
        public async Task<TaskItem?> GetTaskByIdAsync(int taskId)
        {
            return await _contextDb
                .TaskItems
                .Include(t => t.ProjectId)
                .FirstOrDefaultAsync(t => t.TaskId == taskId);
        }

        //return task ?? throw new Exception($"TaskItem with ID {taskId} not found.");    
    
        public async Task<TaskItem> CreateTaskAsync(TaskItem task)
        {
            var project = await _contextDb.Projects.FindAsync(task.ProjectId);
            if (project == null) throw new ArgumentException("Project not found");
        
            _contextDb.TaskItems.Add(task);
            await _contextDb.SaveChangesAsync();
            return task;
        }  

        public async Task<TaskItem?> UpdateTaskStatusAsync(int taskId, TaskStatus status)
        {
            var task = await _contextDb.TaskItems.FindAsync(taskId);
            if(task == null) return null;

            task.Status = status;
            await _contextDb.SaveChangesAsync(); 
            return task;
    } 

        public async Task<bool> DeleteTaskAsync(int taskId) 
        {
            var task = await _contextDb.TaskItems.FindAsync(taskId);    
            if(task == null) return false;

            _contextDb.TaskItems.Remove(task);
            return await _contextDb.SaveChangesAsync() > 0;
        }
        public async Task<TaskItem?> SetTaskDueDateAsync(int taskId, DateTime dueDate)
        {
            var task = await _contextDb.TaskItems.FindAsync(taskId);
            if(task == null) return null;

            task.DueDate = dueDate;
            await _contextDb.SaveChangesAsync();
            return task;
        }
    } */
}

using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class TaskRepository(IAppDbContext context):ITaskRepository
    {
        public Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
            return Task.FromResult(context.Tasks);
        }

        public Task<TaskEntity?> GetTaskByIdAsync(int id)
        {
            return Task.FromResult(context.Tasks.FirstOrDefault(task => task.Id == id));
        }
    }



}

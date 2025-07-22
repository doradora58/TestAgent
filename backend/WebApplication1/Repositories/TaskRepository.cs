
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class TaskRepository(IAppDbContext context):ITaskRepository
    {
        public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
            return context.Tasks;
        }

        public async Task<TaskEntity?> GetTaskByIdAsync(int id)
        {
            return context.Tasks.FirstOrDefault(task => task.Id == id);
        }
    }



}

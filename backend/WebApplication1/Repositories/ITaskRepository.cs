using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
    Task<TaskEntity?> GetTaskByIdAsync(int id);
}
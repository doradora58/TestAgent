using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<TaskDto>> GetAllTasksAsync();
    Task<TaskDto?> GetTaskByIdAsync(int id);
    Task<TaskDto> Add(TaskEntity taskEntity);
    Task<TaskDto> Remove(int id);
    Task UpdateAsync(TaskDto taskToUpdate);
}
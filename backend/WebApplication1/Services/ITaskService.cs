using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetTasksAsync();
        Task<TaskDto> GetTaskByIdAsync(int id);
    }
}

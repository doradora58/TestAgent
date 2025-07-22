using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class TaskService(ITaskRepository taskRepository) :ITaskService
    {
        public async Task<IEnumerable<TaskDto>> GetTasksAsync()
        {
            var tasks = await taskRepository.GetAllTasksAsync();
            return tasks.Select(task => new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                DueDate = task.DueDate
            });
        }

        public async Task<TaskDto> GetTaskByIdAsync(int id)
        {
            var task = await taskRepository.GetTaskByIdAsync(id);

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                DueDate = task.DueDate
            };
        }
    }
}

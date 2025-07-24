using Microsoft.OpenApi.Extensions;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class TaskRepository(IAppDbContext context):ITaskRepository
    {
        public Task<IEnumerable<TaskDto>> GetAllTasksAsync()
        {
            return Task.FromResult(context.Tasks);
        }

        public Task<TaskDto?> GetTaskByIdAsync(int id)
        {
            return Task.FromResult(context.Tasks.FirstOrDefault(task => task.Id == id));
        }

        public Task<TaskDto> Add(TaskEntity taskEntity)
        {
            var id = context.Tasks.Any() ? context.Tasks.Max(task => task.Id) + 1 : 1;
            var newTask = new TaskDto()
            {
                Id = id,
                Title = taskEntity.Title,
                Description = taskEntity.Description,
                PlannedTerm = taskEntity.PlannedTerm,
                ActualTerm = taskEntity.ActualTerm,
                AssignedTo = taskEntity.AssignedTo,
                CreatedAt = DateTime.Now,
                Status = taskEntity.Status
            };
            context.Tasks = context.Tasks.Append(newTask);
            return Task.FromResult(newTask);
        }
    }



}

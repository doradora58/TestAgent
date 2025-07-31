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
                //ActualTerm = taskEntity.ActualTerm,
                //AssignedTo = taskEntity.AssignedTo,
                //CreatedAt = DateTime.Now,
                Status = TaskProgress.New.GetDisplayName()
            };
            context.Tasks = context.Tasks.Append(newTask);
            return Task.FromResult(newTask);
        }

        public Task<TaskDto> Remove(int id)
        {
            var taskToRemove = context.Tasks.FirstOrDefault(task => task.Id == id);
            if (taskToRemove == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }

            context.Tasks = context.Tasks.Where(task => task.Id != id).ToList();
            return Task.FromResult(taskToRemove);
        }

        public async Task UpdateAsync(TaskDto taskToUpdate)
        {
            var currentTask = context.Tasks.FirstOrDefault(task => task.Id == taskToUpdate.Id);
            if (currentTask == null)
            {
                throw new KeyNotFoundException("Task not found");
            }
            //currentTask.Id = taskToUpdate.Id;
            currentTask.Title = taskToUpdate?.Title;
            currentTask.Description = taskToUpdate?.Description;
            currentTask.PlannedTerm = taskToUpdate?.PlannedTerm;
            //currentTask.Status = taskToUpdate?.Status;
            //currentTask.ActualTerm= taskToUpdate?.ActualTerm;
            //currentTask.AssignedTo= taskToUpdate?.AssignedTo;

        }
    }



}

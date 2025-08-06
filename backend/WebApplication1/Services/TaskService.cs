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
                PlannedTerm = task.PlannedTerm,
                ActualTerm = task.ActualTerm,
                AssignedTo = task.AssignedTo,
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
                PlannedTerm = task.PlannedTerm,
                ActualTerm = task.ActualTerm,
                AssignedTo = task.AssignedTo,
            };
        }


        public async Task<TaskEntity> CreateTaskAsync(TaskEntity taskEntity)
        {
            if (string.IsNullOrEmpty(taskEntity.Title))
            {
                throw new ArgumentException("Task cannot be empty");
            }
            var task = await taskRepository.Add(taskEntity);
            return new TaskEntity
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                //Status = task.Status,
                PlannedTerm = task.PlannedTerm,
                //ActualTerm = task.ActualTerm,
            };
        }

        public async Task<TaskDto> DeleteTaskAsync(int id)
        {
            
            var task = await taskRepository.Remove(id);
            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                PlannedTerm = task.PlannedTerm,
                ActualTerm = task.ActualTerm,
                AssignedTo = task.AssignedTo,
            };
        }

        public async Task<TaskDto> UpdateTaskAsync(int id, TaskEntity updatedTask)
        {
            var taskToUpdate = await taskRepository.GetTaskByIdAsync(id);

            if (taskToUpdate == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} not found.");
            }

            taskToUpdate.Title = updatedTask.Title;
            taskToUpdate.Description = updatedTask.Description;
            taskToUpdate.PlannedTerm = updatedTask.PlannedTerm;
            //taskToUpdate.ActualTerm = updatedTask.ActualTerm;
            //taskToUpdate.AssignedTo = updatedTask.AssignedTo;
            //taskToUpdate.Status = updatedTask.Status;

            await taskRepository.UpdateAsync(taskToUpdate);

            return taskToUpdate;
        }
    }
}

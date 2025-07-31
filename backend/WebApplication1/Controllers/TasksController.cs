using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController(ITaskService taskService, ILogger<TasksController> logger) : ControllerBase
    {


        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await taskService.GetTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await taskService.GetTaskByIdAsync(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskEntity taskEntity)
        {
            try
            {
                var newTask = await taskService.CreateTaskAsync(taskEntity);
                return Ok(newTask);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var removedTask= await taskService.DeleteTaskAsync(id);
                return Ok(removedTask);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal error: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskEntity taskEntity)
        {
            if (id != taskEntity.Id)
            {
                return BadRequest("Id not found");
            }

            try
            {
                var updatedTask = await taskService.UpdateTaskAsync(id, taskEntity);
                return Ok(updatedTask);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal error: {ex.Message}");
            }
        }
    }


}

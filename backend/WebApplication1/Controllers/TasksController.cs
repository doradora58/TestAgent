using Microsoft.AspNetCore.Mvc;
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
    }


}

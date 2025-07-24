using WebApplication1.Models;

namespace WebApplication1.Data
{
    public interface IAppDbContext
    {
        IEnumerable<TaskDto> Tasks { get; set; }
    }

}

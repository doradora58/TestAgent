using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options, IEnumerable<TaskDto> tasks) : DbContext(options) ,IAppDbContext
    {
        public IEnumerable<TaskDto> Tasks { get; set; } = tasks;
    }
}

using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options, IEnumerable<TaskEntity> tasks) : DbContext(options) ,IAppDbContext
    {
        public IEnumerable<TaskEntity> Tasks { get; set; } = tasks;
    }
}

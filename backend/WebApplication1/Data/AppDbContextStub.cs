using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContextStub : IAppDbContext
    {
        public IEnumerable<TaskEntity> Tasks { get; set; } = new FakeDbSet<TaskEntity>();

    }

}

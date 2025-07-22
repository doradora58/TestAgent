using System.Collections;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    // ReSharper disable once InconsistentNaming
    public class FakeDbSet<T> :IEnumerable<TaskEntity>
    {
        private readonly List<TaskEntity> _data = new()
        {
            new TaskEntity()
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                Description = "aaa",
                DueDate = DateTime.Now.Add(TimeSpan.FromDays(1)),
                Status = "Active",
                Title = "Abcde",
            },
            new TaskEntity()
            {
                Id = 2,
                CreatedAt = DateTime.Now,
                Description = "bbbb",
                DueDate = DateTime.Now.Add(TimeSpan.FromDays(1)),
                Status = "Active",
                Title = "ABCDE",
            }
        };


        public IEnumerator<TaskEntity> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

using System.Collections;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    // ReSharper disable once InconsistentNaming
    public class FakeDbSet :IEnumerable<TaskEntity>
    {
        private readonly List<TaskEntity> _data = new()
        {
            new TaskEntity()
            {
                Id = 1,
                Title = "Abcde",
                CreatedAt = DateTime.Now,
                Description = "aaa",
                Status = TaskProgress.New,
                PlannedTerm = new PlannedTerm()
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.Add(TimeSpan.FromDays(1)),
                },
                ActualTerm = new ActualTerm(),
                AssignedTo = "Me",
            },
            new TaskEntity()
            {
                Id = 2,
                Title = "ABCDE",
                CreatedAt = DateTime.Now.Add(TimeSpan.FromDays(1)),
                Description = "aaa",
                Status = TaskProgress.New,
                PlannedTerm = new PlannedTerm()
                {
                    StartDate = DateTime.Now.Add(TimeSpan.FromDays(1)),
                    EndDate = DateTime.Now.Add(TimeSpan.FromDays(2)),
                },
                ActualTerm = new ActualTerm(),
                AssignedTo = "Me",
            },
            new TaskEntity()
            {
                Id =3,
                Title = "ABCDE",
                CreatedAt = DateTime.Now.Add(TimeSpan.FromDays(5)),
                Description = "aaa",
                Status = TaskProgress.New,
                PlannedTerm = new PlannedTerm()
                {
                    StartDate = DateTime.Now.Add(TimeSpan.FromDays(5)),
                    EndDate = DateTime.Now.Add(TimeSpan.FromDays(8)),
                },
                ActualTerm = new ActualTerm(),
                AssignedTo = "Me",
            },
            new TaskEntity()
            {
                Id = 4,
                Title = "ABCDE",
                CreatedAt = DateTime.Now.Add(TimeSpan.FromDays(10)),
                Description = "aaa",
                Status = TaskProgress.New,
                PlannedTerm = new PlannedTerm()
                {
                    StartDate = DateTime.Now.Add(TimeSpan.FromDays(10)),
                    EndDate = DateTime.Now.Add(TimeSpan.FromDays(19)),
                },
                ActualTerm = new ActualTerm(),
                AssignedTo = "Me",
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

using System.Collections;
using Microsoft.OpenApi.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    // ReSharper disable once InconsistentNaming
    public class FakeDbSet :IEnumerable<TaskDto>
    {
        private readonly List<TaskDto> _data = new()
        {
            new TaskDto()
            {
                Id = 1,
                Title = "Abcde",
                CreatedAt = DateTime.Now,
                Description = "aaa",
                Status = TaskProgress.New.GetDisplayName(),
                PlannedTerm = new PlannedTerm()
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.Add(TimeSpan.FromDays(3)),
                },
                ActualTerm = new ActualTerm(),
                AssignedTo = "Me",
            },
            new TaskDto()
            {
                Id = 2,
                Title = "ABCDE",
                CreatedAt = DateTime.Now.Add(TimeSpan.FromDays(3)),
                Description = "aaa",
                Status = TaskProgress.New.GetDisplayName(),
                PlannedTerm = new PlannedTerm()
                {
                    StartDate = DateTime.Now.Add(TimeSpan.FromDays(3)),
                    EndDate = DateTime.Now.Add(TimeSpan.FromDays(6)),
                },
                ActualTerm = new ActualTerm(),
                AssignedTo = "Me",
            },
            new TaskDto()
            {
                Id =3,
                Title = "ABCDE",
                CreatedAt = DateTime.Now.Add(TimeSpan.FromDays(5)),
                Description = "aaa",
                Status = TaskProgress.New.GetDisplayName(),
                PlannedTerm = new PlannedTerm()
                {
                    StartDate = DateTime.Now.Add(TimeSpan.FromDays(5)),
                    EndDate = DateTime.Now.Add(TimeSpan.FromDays(8)),
                },
                ActualTerm = new ActualTerm(),
                AssignedTo = "Me",
            },
            new TaskDto()
            {
                Id = 4,
                Title = "ABCDE",
                CreatedAt = DateTime.Now.Add(TimeSpan.FromDays(10)),
                Description = "aaa",
                Status = TaskProgress.New.GetDisplayName(),
                PlannedTerm = new PlannedTerm()
                {
                    StartDate = DateTime.Now.Add(TimeSpan.FromDays(10)),
                    EndDate = DateTime.Now.Add(TimeSpan.FromDays(19)),
                },
                ActualTerm = new ActualTerm(),
                AssignedTo = "Me",
            }
        };


        public IEnumerator<TaskDto> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

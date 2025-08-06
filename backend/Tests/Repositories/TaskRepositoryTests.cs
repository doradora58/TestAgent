using Moq;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace Tests.Repositories
{
    [TestClass]
    public class TaskRepositoryTests
    {
        private Mock<IAppDbContext> _mockContext;
        private TaskRepository _taskRepository;

        [TestInitialize]
        public void SetUp()
        {
            _mockContext = new Mock<IAppDbContext>();
            _mockContext.Setup(c => c.Tasks).Returns(new List<TaskDto>
            {
                new TaskDto { Id = 1, Title = "Task1", Description = "First Task" },
                new TaskDto { Id = 2, Title = "Task2", Description = "Second Task" }
            });

            _taskRepository = new TaskRepository(_mockContext.Object);
        }

        [TestMethod]
        public void GetAllTasksAsync_ShouldReturnAllTasks()
        {
            // Act
            var tasks = _taskRepository.GetAllTasksAsync().Result;

            // Assert
            Assert.IsNotNull(tasks);
            Assert.AreEqual(2, tasks.Count());
            Assert.AreEqual("Task1", tasks.First().Title);
        }

        [TestMethod]
        public void GetTaskByIdAsync_ShouldReturnTask_WhenIdExists()
        {
            // Arrange
            var taskId = 1;

            // Act
            var task = _taskRepository.GetTaskByIdAsync(taskId).Result;

            // Assert
            Assert.IsNotNull(task);
            Assert.AreEqual("Task1", task.Title);
        }

        [TestMethod]
        public void GetTaskByIdAsync_ShouldReturnNull_WhenIdDoesNotExist()
        {
            // Arrange
            var taskId = 99;

            // Act
            var task = _taskRepository.GetTaskByIdAsync(taskId).Result;

            // Assert
            Assert.IsNull(task);
        }

        [TestMethod]
        public void Add_ShouldAddTaskAndReturnIt()
        {
            // Arrange
            var newTask = new TaskEntity
            {
                Title = "New Task",
                Description = "Description for new task",
                PlannedTerm =new PlannedTerm()
                {
                    StartDate = Convert.ToDateTime("2025-08-08"),
                    EndDate = Convert.ToDateTime("2025-08-08")
                }
            };

            // Act
            var addedTask = _taskRepository.Add(newTask).Result;

            // Assert
            Assert.IsNotNull(addedTask);
            Assert.AreEqual("New Task", addedTask.Title);
            Assert.AreEqual("Description for new task", addedTask.Description);
        }

        //[TestMethod]
        //public void Remove_ShouldRemoveTask_WhenIdExists()
        //{
        //    // Arrange
        //    var taskId = 1;

        //    // Act
        //    var removedTask = _taskRepository.Remove(taskId).Result;

        //    // Assert
        //    Assert.IsNotNull(removedTask);
        //    Assert.AreEqual("Task1", removedTask.Title);
        //    Assert.IsFalse(_mockContext.Object.Tasks.Any(task => task.Id == taskId));
        //}

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Remove_ShouldThrowException_WhenIdDoesNotExist()
        {
            // Arrange
            var taskId = 99;

            // Act
            _taskRepository.Remove(taskId).Wait();
        }

        [TestMethod]
        public void UpdateAsync_ShouldUpdateTask_WhenTaskExists()
        {
            // Arrange
            var updatedTask = new TaskDto { Id = 1, Title = "Updated Title", Description = "Updated Description" };

            // Act
            _taskRepository.UpdateAsync(updatedTask).Wait();

            // Assert
            var currentTask = _mockContext.Object.Tasks.First(task => task.Id == updatedTask.Id);
            Assert.AreEqual("Updated Title", currentTask.Title);
            Assert.AreEqual("Updated Description", currentTask.Description);
        }
    }
}

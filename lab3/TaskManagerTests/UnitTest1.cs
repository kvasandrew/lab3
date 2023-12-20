using Lab3TaskManager;
using System.Threading.Tasks;

namespace TaskManagerTests
{
    public class Tests
    {

        [TestCase("Noname","Low")]
        public void AddTaskPriority_ShouldAddPriority(string task, string priority)
        {
            // arrange
            var taskManager = new TaskManagement();
            var Testtask = new Lab3TaskManager.Task(task,"Nothing",null,false);
            taskManager.AddTask(Testtask);
            // act
            taskManager.AddTaskPriority(task, priority);

            //assert
            Assert.IsTrue(Testtask.Priority.Contains(priority));
        }

        [Test]
        public void AddTaskPriority_TryAddWrongTaskName_ShouldThrowInvalidOperationException()
        {
            // arrange
            var taskManager = new TaskManagement();
            var title = "Test";
            var priority = "Low";

            //act and assert
            Assert.Throws<InvalidOperationException>(() => taskManager.AddTaskPriority(title, priority));
        }

        [Test]
        public void AddTaskPriority_TryAddWrongPriority_ShouldThrowInvalidOperationException()
        {
            // arrange
            var taskManager = new TaskManagement();
            var task = new Lab3TaskManager.Task();
            var priority = "Test";

            //act and assert
            Assert.Throws<InvalidOperationException>(() => taskManager.AddTaskPriority(task.Title, priority));
        }

        [Test]
        public void RemoveTaskPriority_ShouldRemovePriority()
        {
            // arrange
            var taskManager = new TaskManagement();
            var task = new Lab3TaskManager.Task();
            taskManager.AddTask(task);
            var priority = "Low";
            taskManager.AddTaskPriority(task.Title, priority);

            //act
            taskManager.RemoveTaskPriority(task.Title);

            //assert
            Assert.IsTrue(task.Priority == null);
        }

        [Test]
        public void RemoveTaskPriority_TryAddWrongTaskName_ShouldThrowInvalidOperationException()
        {
            // arrange
            var taskManager = new TaskManagement();
            var title = "Test";

            //act and assert
            Assert.Throws<InvalidOperationException>(() => taskManager.RemoveTaskPriority(title));
        }

        [Test]
        public void AddTask_ShouldAddTask()
        {
            // arrange
            var taskManager = new TaskManagement();
            var task = new Lab3TaskManager.Task();

            //act
            taskManager.AddTask(task);

            //assert
            Assert.IsTrue(taskManager.Tasks.Contains(task));
        }

        [Test]
        public void AddTask_TryAddNotValidTask_ShouldThrowInvalidOperationException()
        {
            // arrange
            var taskManager = new TaskManagement();
            var task = new Lab3TaskManager.Task(null," ","Low",false);

            //act and assert
            Assert.Throws<InvalidOperationException>(() => taskManager.AddTask(task));
        }

        [Test]
        public void AddTask_TryAddExistedTask_ShouldThrowInvalidOperationException()
        {
            // arrange
            var taskManager = new TaskManagement();
            var task = new Lab3TaskManager.Task("Test", "Test", "Low", false);
            taskManager.AddTask(task);
            //act and assert
            Assert.Throws<InvalidOperationException>(() => taskManager.AddTask(task));
        }

        [Test]
        public void Remove_ShouldRemoveTask()
        {
            // arrange
            var taskManager = new TaskManagement();
            var task = new Lab3TaskManager.Task();
            taskManager.AddTask(task);

            //act
            taskManager.RemoveTask(task.Title);

            //assert
            Assert.IsFalse(taskManager.Tasks.Contains(task));
        }

        [TestCase("Test")]
        public void RemoveTask_TryRemoveNotExistedTask_ShouldThrowInvalidOperationException(string tasktitle)
        {
            // arrange
            var taskManager = new TaskManagement();

            //act and assert
            Assert.Throws<InvalidOperationException>(() => taskManager.RemoveTask(tasktitle));
        }
    }
}
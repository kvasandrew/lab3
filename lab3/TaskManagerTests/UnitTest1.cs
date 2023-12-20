using Lab3TaskManager;
using System.Threading.Tasks;

namespace TaskManagerTests
{
    public class Tests
    {

        [TestCase("Noname", "Low")]
        public void AddTaskPriority_ShouldAddPriority(string task, string priority)
        {
            // arrange
            var taskManager = new TaskManagement();
            var Testtask = new Lab3TaskManager.Task(task, "Nothing", null, false);
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
            var task = new Lab3TaskManager.Task(null, " ", "Low", false);

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


        [Test]
        public void AddTaskToFavorite_ShouldAddTaskToFavorite()
        {
            // arrange
            var taskManager = new TaskManagement();
            var task = new Lab3TaskManager.Task();
            taskManager.AddTask(task);

            //act
            taskManager.AddTaskToFavorite(task.Title);

            //assert
            Assert.IsTrue(taskManager.Tasks.First(x => x.Title == task.Title).Favorite == true);
        }

        [TestCase("Test")]
        public void AddTaskToFavorite_TryAddToFavoriteNotExistedTask_ShouldThrowInvalidOperationException(string taskTitle)
        {
            // arrange
            var taskManager = new TaskManagement();

            //act and assert
            Assert.Throws<InvalidOperationException>(() => taskManager.AddTaskToFavorite(taskTitle));
        }
        [Test]
        public void RemoveTaskFromFavorite_ShouldRemoveTaskFromFavorite()
        {
            // arrange
            var taskManager = new TaskManagement();
            var task = new Lab3TaskManager.Task("Test", "Test", "Low", false);
            taskManager.AddTask(task);
            taskManager.AddTaskToFavorite(task.Title);

            //act
            taskManager.RemoveTaskFromFavorite(task.Title);

            //assert
            Assert.IsTrue(taskManager.Tasks.First(x => x.Title == task.Title).Favorite == false);
        }

        [TestCase("Test")]
        public void RemoveTaskFromFavorite_TryRemoveFromFavoriteNotExistedTask_ShouldThrowInvalidOperationException(string taskTitle)
        {
            // arrange
            var taskManager = new TaskManagement();

            //act and assert
            Assert.Throws<InvalidOperationException>(() => taskManager.RemoveTaskFromFavorite(taskTitle));
        }

        [Test]
        public void GetFavoriteTasks_ShouldGetFavoriteTasks()
        {
            //arrange
            var taskManager = new TaskManagement();
            List<Lab3TaskManager.Task> test = new List<Lab3TaskManager.Task> {
                new Lab3TaskManager.Task("Test1","Test1","Low",true),
                new Lab3TaskManager.Task("Test2", "Test2", "Low", true)};

            taskManager.AddTask(test[0]);
            taskManager.AddTask(test[1]);

            //act
            var res = taskManager.GetFavoriteTasks();

            //assert
            Assert.IsTrue(res.SequenceEqual(test));
        }

        [TestCase("Low")]
        public void GetTasksByPriority_ShouldGetTasksByPriority(string priority)
        {
            //arrange
            var taskManager = new TaskManagement();
            List<Lab3TaskManager.Task> test = new List<Lab3TaskManager.Task> {
                new Lab3TaskManager.Task("Test1","Test1","Low",true),
                new Lab3TaskManager.Task("Test2", "Test2", "Low", true)};

            taskManager.AddTask(test[0]);
            taskManager.AddTask(test[1]);

            //act
            var res = taskManager.GetTasksByPriority(priority);

            //assert
            Assert.IsTrue(res.SequenceEqual(test));
        }

        [TestCase("Test")]
        public void GetTasksByPriority_TryGetTasksByWrongPriority_ShouldThrowInvalidOperationException(string priority)
        {
            //arrange
            var taskManager = new TaskManagement();

            //act and assert
            Assert.Throws<InvalidOperationException>(() => taskManager.GetTasksByPriority(priority));
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3TaskManager
{
    public class TaskManagement
    {
        public List<Task> Tasks { get; }

        public TaskManagement() { Tasks = new List<Task>(); }
        public bool CheckPriority(string priority)
        {
            switch (priority)
            {
                case null:
                case "Lowest":
                case "Low":
                case "Medium":
                case "High":
                case "Highest":
                    return true;
                default: return false;
            }
        }
        public bool IsValid(Task task)
        {
            if (string.IsNullOrWhiteSpace(task.Title) || string.IsNullOrWhiteSpace(task.Description) || !CheckPriority(task.Priority)) return false; return true;
        }
        private bool TaskExist(string title){return Tasks.Where(x => x.Title == title).Any();}
       


        public void AddTaskPriority(string task, string priority) 
        {
            if(!TaskExist(task))
                throw new InvalidOperationException($"Task {task} doesn`t exist. ");
            if (!CheckPriority(priority))
                throw new InvalidOperationException($"Wrong Priority {priority} for Task {task}. ");
                
            Tasks.First(x => x.Title == task).Priority = priority;
        }
        public void RemoveTaskPriority(string task)
        {
            if (!TaskExist(task))
                throw new InvalidOperationException($"Task {task} doesn`t exist. ");
            Tasks.First(x => x.Title == task).Priority = null;
        }
        public void AddTask (Task task)
        {
            if (!IsValid(task))
                throw new InvalidOperationException("Task isn`t valid. ");
            if (TaskExist(task.Title))
                throw new InvalidOperationException($"Task {task.Title} already exists. ");

            Tasks.Add(task);
        }
        public void RemoveTask(string task)
        {
            if (!TaskExist(task))
                throw new InvalidOperationException($"Task {task} doesn`t exists. ");
            Tasks.Remove(Tasks.First(x => x.Title == task));
        }
        public void AddTaskToFavorite(string task)
        {
            if (!TaskExist(task))
                throw new InvalidOperationException($"Task {task} doesn`t exists. ");
            Tasks.First(x => x.Title == task).Favorite = true;
        }
        public void RemoveTaskFromFavorite(string taskTitle)
        {
            if (!TaskExist(taskTitle))
                throw new InvalidOperationException($"Task {taskTitle} doesn`t exists. ");
            Tasks.First(x => x.Title == taskTitle).Favorite = false;
        }

        public List<Task> GetFavoriteTasks()
        {
            return Tasks.Where(x => x.Favorite == true).OrderBy(x => x.Title).ToList();
        }
        
        public List<Task> GetTasksByPriority(string priority)
        {
            if (!CheckPriority(priority))
                throw new InvalidOperationException($"Wrong Priority {priority}. ");

            return Tasks.Where(x => x.Priority == priority).OrderBy(x => x.Title).ToList();
        }
    }
}

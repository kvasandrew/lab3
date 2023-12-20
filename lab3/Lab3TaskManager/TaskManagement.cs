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
       

        
    }
}

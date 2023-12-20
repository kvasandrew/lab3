using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3TaskManager
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public bool Favorite { get; set; }
        public Task(string title,string description, string priority, bool favorite) 
        { 
            Title = title;
            Description = description;
            Priority = priority;
            Favorite = favorite;
        }

            
        public Task()
        {

            Title = "Noname";
            Description = "Nothing";
            Priority = null;
            Favorite = false;
        }
  

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo_list
{
    public class TaskManager
    {
        private List<Task> tasks;

        public TaskManager()
        {
            tasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            tasks.Add(task);
            Console.WriteLine(task.Description);
        }

        public List<Task> SearchByTags(List<string> tags)
        {
            return tasks.Where(task => task.Tags.Intersect(tags).Any()).ToList();
        }

        public List<Task> GetActualTasks(int count)
        {

            return tasks.OrderBy(task => task.Deadline).Take(count).ToList();
        }
    }
}
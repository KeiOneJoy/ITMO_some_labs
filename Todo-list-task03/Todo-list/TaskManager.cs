using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace Todo_list
{
    public class TaskManager
    {
        private List<Task> tasks;
        private JsonDataSaver jsonStorage;
        private XmlDataSaver xmlStorage;
        
        public TaskManager()
        {
            tasks = new List<Task>();
            jsonStorage = new JsonDataSaver();
            xmlStorage = new XmlDataSaver();    
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
            return tasks
                .Where(task => task.Deadline != null) 
                .OrderBy(task => task.Deadline) 
                .Take(count) 
                .ToList();
        }
        public void SaveTasksToJson()
        {
            jsonStorage.SaveData(tasks);
        }
        public void LoadTasksFromJson() {
            tasks = jsonStorage.LoadData();
        }
        public void SaveTasksToXml() 
        {
            xmlStorage.SaveData(tasks);
        }
        public void LoadTasksFromXml() {
            tasks = xmlStorage.LoadData();
        }
        public void SaveTasksToSQLite()
        {
            using (var db = new TodoContext())
            { 
                ClearDatabase();

                foreach (var task in tasks)
                {
                    db.Tasks.Add(task);
                }
                db.SaveChanges();
            }
        }
        public void LoadTasksFromSQlite()
        {
            using (var db = new TodoContext())
            {
                tasks = db.Tasks.ToList();
            }
        }
        public void ClearDatabase()
        {
            using (var db = new TodoContext())
            {
                db.Tasks.RemoveRange(db.Tasks);
                db.SaveChanges();
            }
        }

    }

}
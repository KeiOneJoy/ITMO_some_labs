using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Todo_list
{
    public class JsonDataSaver : IDataSaver
    {
        private string filePath;

        public void SaveData(List<Task> tasks)
        {
            if(string.IsNullOrEmpty(filePath))
            {
               filePath = "Todo.json";
            }
            string jsonString = JsonSerializer.Serialize(tasks);
         
            File.WriteAllText(filePath, jsonString);
        }

        public List<Task> LoadData()
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("File path is not specified.", nameof(filePath));
            }
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Task>>(jsonString);
        }
    }
}

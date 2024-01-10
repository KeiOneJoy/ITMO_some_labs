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
        private readonly string filePath;

        public JsonDataSaver(string _filePath)
        {
            filePath = _filePath;
        }
        public void SaveData(List<Task> tasks)
        {
            string jsonString = JsonSerializer.Serialize(tasks);
            File.WriteAllText(filePath, jsonString);
        }

        public List<Task> LoadData()
        {
            if (!File.Exists(filePath)) {
                return new List<Task>();
            }
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Task>>(jsonString);
        }
    }
}

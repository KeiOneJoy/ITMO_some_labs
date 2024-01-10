using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Todo_list
{
    public class XmlDataSaver : IDataSaver
    {
        private string filePath;


        public void SaveData(List<Task> tasks)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                filePath = "Todo.xml";
            }
            var serializer = new XmlSerializer(typeof(List<Task>));
            using (var writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, tasks);
            }
        }

        public List<Task> LoadData()
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException("File path is not specified.", nameof(filePath));
            }
            var serializer = new XmlSerializer (typeof(List<Task>));
            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                return (List<Task>)serializer.Deserialize(reader);
            }
        }
    }
}

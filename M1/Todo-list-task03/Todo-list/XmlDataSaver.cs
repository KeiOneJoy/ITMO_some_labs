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
        private readonly string filePath;

        public XmlDataSaver(string _filePath)
        {
            filePath = _filePath;
        }

        public void SaveData(List<Task> tasks)
        {
            var serializer = new XmlSerializer(typeof(List<Task>));
            StreamWriter myWriter = new StreamWriter(filePath);
            serializer.Serialize(myWriter, tasks);
        }

        public List<Task> LoadData()
        {
            if (!File.Exists(filePath)) return new List<Task>();
            var serializer = new XmlSerializer (typeof(List<Task>));
            using var reader = new FileStream(filePath,FileMode.Open);
            return (List<Task>)serializer.Deserialize(reader);
        }
    }
}

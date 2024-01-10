using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_list
{
    public class Task
    {
        public string Title { get;}
        public string Description { get;}
        public DateTime Deadline { get; }
        public List<string> Tags { get; set; }

        public Task(string title, string description, DateTime deadline, List<string> tags)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            if (tags == null)
            {
                throw new ArgumentNullException(nameof(tags));
            }

            Title = title;
            Description = description;  
            Deadline = deadline;
            Tags = tags;
        }
        public override string ToString()
        {
            return Title;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

public class Task
{

    public string Title { get; set; }
    public int Id { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    [NotMapped]
    public List<string> Tags { get; set; }

    public Task(string title, string description, DateTime deadline, List<string> tags)
    {
        if (string.IsNullOrWhiteSpace(title))
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

    public Task(int id, string title, string description, DateTime deadline, List<string> tags)
        : this(title, description, deadline, tags)
    {
        Id = id;
    }

    public Task()
    {
    }
}
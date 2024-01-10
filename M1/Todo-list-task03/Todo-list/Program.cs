using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Todo_list
{
    class Program
    {
        static void Main()
        {
            TaskManager manager = new TaskManager();
            bool isActive = true;


            while (isActive)
            {
                Console.WriteLine("Menu: ");
                Console.WriteLine("1. Add task");
                Console.WriteLine("2. Search task");
                Console.WriteLine("3. Actual tasks");
                Console.WriteLine("4. Save Data");
                Console.WriteLine("5. Load Data");
                Console.WriteLine("6. Exit");
                Console.Write("> ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Title: ");
                        string title = Console.ReadLine();

                        Console.WriteLine("Description: ");
                        string description = Console.ReadLine();

                        Console.WriteLine("Deadline (dd.MM.yyyy): ");
                        DateTime deadline;
                        while (!DateTime.TryParse(Console.ReadLine(), out deadline))
                        {
                            Console.Write("Invalid date, please re-enter (dd.MM.yyyy):");
                        }

                        List<string> tags = new List<string>();
                        Console.WriteLine("Tags (finish on empty line)");
                        string tag;
                        while (!string.IsNullOrEmpty(tag = Console.ReadLine()))
                        {
                            tags.Add(tag);
                        }

                        Task newTask = new Task(title, description, deadline, tags);
                        manager.AddTask(newTask);
                        Console.WriteLine("Task added successfully!");

                        break;

                    case "2":
                        Console.WriteLine("Search tasks by tag");
                        var searchTags = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        var foundTasks = manager.SearchByTags(searchTags);
                       

                        if(foundTasks.Count == 0)
                        {
                            Console.WriteLine("No such tasks");
                        }
                        else
                        {
                            foreach(var task in foundTasks)
                            {
                                Console.WriteLine($"Title: {task.Title}, Description: {task.Description}, Deadline: {task.Deadline.ToString("dd.MM.yyyy")}, Tags: {string.Join(", ", task.Tags)} ");
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("How many actual tasks to display?");
                        int n = int.Parse(Console.ReadLine());

                        var actualTasks = manager.GetActualTasks(n);
                        if (actualTasks.Count == 0)
                        {
                            Console.WriteLine("No tasks available.");
                            break;
                        }

                        if (actualTasks.Count < n)
                        {
                            Console.WriteLine($"Only {actualTasks.Count} tasks available:");
                        }
                        else
                        {
                            Console.WriteLine("Actual tasks: ");
                        }
                        foreach (var task in actualTasks)
                        {
                            string deadlineStr = task.Deadline.ToString("dd.MM.yyyy");
                            string tagsStr = task.Tags != null ? string.Join(", ", task.Tags) : "No Tags";

                            Console.WriteLine($"Title: {task.Title}, Description: {task.Description}, Deadline: {deadlineStr}, Tags: {tagsStr}");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Choose format to save: 1. JSON 2. XML 3. SQLite");
                        string saveOption = Console.ReadLine();

                        switch (saveOption)
                        {
                            case "1":                             
                                manager.SaveTasksToJson();
                                Console.WriteLine("Saved to JSON successfully!");
                                break;
                            case "2":
                                manager.SaveTasksToXml();
                                Console.WriteLine("Saved to XML successfully!");
                                break;
                            case "3":
                                manager.SaveTasksToSQLite();
                                Console.WriteLine("Saved to SQlite successfully!");
                                break;

                        }
                        break;
                    case "5":
                        Console.WriteLine("Choose format to load: 1. JSON 2. XML 3. SQLite");
                        string loadOption = Console.ReadLine();

                        switch (loadOption)
                        {
                            case "1":
                                manager.LoadTasksFromJson();
                                Console.WriteLine("Load from JSON successfully!");
                                break;
                            case "2":
                                manager.LoadTasksFromXml();
                                Console.WriteLine("Load from XML successfully!");
                                break;
                            case "3":
                                manager.LoadTasksFromSQlite();
                                Console.WriteLine("Load from SQlite successfully!");
                                break;
                        }
                        break;
                    case "6":
                        isActive = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;

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
                Console.WriteLine("3. Least tasks");
                Console.WriteLine("4. Exit");
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
                        Console.WriteLine(searchTags);

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
                        var actualTasks = manager.GetActualTasks(5);
                        Console.WriteLine("Actual tasks");
                        foreach(var task in actualTasks)
                        {
                            Console.WriteLine($"Title: {task.Title}, Description: {task.Description}, Deadline: {task.Deadline.ToString("dd.MM.yyyy")}, Tags: {string.Join(", ", task.Tags)} ");
                        }
                        break;
                    case "4":
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
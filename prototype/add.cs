using System;
using System.Collections.Generic;

public static class AddTask
{
    public static void Add(List<ToDoTask> tasks)
    {
        Console.WriteLine("Task name: ");
        string taskName = Console.ReadLine();

        Console.WriteLine("Task description: ");
        string taskDespriction = Console.ReadLine();

        ToDoTask newTask = new ToDoTask(taskName, taskDespriction);
        tasks.Add(newTask);

        Console.WriteLine("Task added!");
    }    
}

public static class AddProperty
{
    public static void Add(List<ToDoTask> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No current tasks.");
            return;
        }

        Console.WriteLine("Pick a task number: ");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i].Title}");
        }

        Console.WriteLine("Task number: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int taskNumber))
        {
            int index = taskNumber - 1;

            if (index < 0 || index >= tasks.Count)
            {
                Console.WriteLine("Invalid task number!");
                return;
            }

            Console.Write("Property name: ");
            string propertyName = Console.ReadLine();

            Console.Write("Property value: ");
            string propertyValue = Console.ReadLine();

            tasks[index].AddProperty(new TextProperty(propertyName, propertyValue));            
            Console.WriteLine("Property added!");
        }
        else
        {
            Console.WriteLine("Invalid input, you must type a number!");
        }
    }
}
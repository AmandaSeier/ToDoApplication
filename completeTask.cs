using System;
using System.Collections.Generic;
using ToDoApplication.Models.properties;
using ToDoApplication.Models;

public static class TaskState {
    public static void Complete(List<ToDoTask> tasks, List<ToDoTask> finishedTasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("You have no current tasks.");
            return;
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            tasks[i].ShowTask();
            Console.WriteLine();
        }

        Console.WriteLine("Choose a task that you wanna mark as done: ");
        string chosenNum = Console.ReadLine();

        if (int.TryParse(chosenNum, out int finishedTask))
        {
            int index = finishedTask - 1;

            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].CompleteTask();
                Console.WriteLine($"Success! '{tasks[index].Title}' has been marked as done!");
                finishedTasks.Add(tasks[index]);
                tasks.RemoveAt(index);
            }
            else
            {
                Console.WriteLine($"Invalid tasknumber! You need to choose a number between 1 and {tasks.Count}.");
            }
        }
        else
        {
            Console.WriteLine("Invalid argument, you need to write a number!");
        }
    }
}
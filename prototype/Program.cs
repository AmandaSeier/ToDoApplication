using System;
using System.Collections.Generic;

List<ToDoTask> tasks = new List<ToDoTask>();
List<ToDoTask> finishedTasks = new List<ToDoTask>();

while (true)
{
    Console.Clear();
    Menu.PrintMenu();

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        AddTask.Add(tasks);
    }
    else if (choice == "2")
    {
        Info.Overview(tasks);
    }
    else if (choice == "3")
    {
        AddProperty.Add(tasks);
    }
    else if (choice == "4")
    {
        TaskState.Complete(tasks, finishedTasks); 
    }
    else if (choice == "5")
    {
        Info.FinishedOverview(finishedTasks);
    }        
    else if (choice == "6")
    {
        EditTask.Edit(tasks);
    }
    else if (choice == "7")
    {
        Console.WriteLine("Quitting program...");
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice, try again.");
    }
    if (choice != "7")
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
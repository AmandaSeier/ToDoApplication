using System;
using Avalonia;

namespace ToDoApplication;

class Program
{
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
}

// PROTOTYPE 
/*
using System;
using System.Collections.Generic;
using ToDoApplication.Models.properties;
using ToDoApplication.Models;

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
} */
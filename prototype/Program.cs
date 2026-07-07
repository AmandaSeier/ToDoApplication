using System;
using System.Collections.Generic;

List<ToDoTask> tasks = new List<ToDoTask>();

while (true)
{
    Console.Clear();
    Menu.printMenu();

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        AddTask.Add(tasks);
    }
    else if (choice == "2")
    {
        Info.Overreview(tasks);
    }
    else if (choice == "3")
    {
        AddProperty.Add(tasks);
    }
    else if (choice == "4")
    {
        Console.WriteLine("Quitting program...");
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice, try again.");
        
    }
    if (choice != "4")
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}

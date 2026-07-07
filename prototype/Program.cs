using System;
using System.Collections.Generic;

List<string> tasks = new List<string>();

while (true)
{
    Console.WriteLine("\n----- TO-DO -----\n");
    Console.WriteLine("1. Add task");
    Console.WriteLine("2. Show current tasks");
    Console.WriteLine("3. End\n");
    Console.Write("Choose either 1, 2 or 3: ");

    string choice = Console.ReadLine();

    // Adding tasks to the list
    if (choice == "1")
    {
        addTask.add(tasks);
    }
    // Access to the task list
    else if (choice == "2")
    {
        info.overreview(tasks);
    }
    // End of program
    else if (choice == "3")
    {
        Console.WriteLine("Closing program ...");
        break;
    }
    // Invalid choice
    else
    {
        Console.WriteLine("Invalid choice, choose either 1, 2, or 3. Try again!!!");
    }
}
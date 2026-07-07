using System;
using System.Collections.Generic;

public static class addTask
{
    public static void add(List<string> tasks)
    {
    Console.WriteLine("Task name: ");
    string task = Console.ReadLine();
    tasks.Add(task);
    Console.WriteLine("Task added!");
    }    
}

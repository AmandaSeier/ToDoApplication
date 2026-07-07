using System;
using System.Collections.Generic;

public static class Info {
    public static void Overreview(List<ToDoTask> tasks)
    {
        Console.WriteLine("Your tasks: ");

            if (tasks.Count == 0)
            {
                Console.WriteLine("You have no current tasks added!");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    tasks[i].ShowTask();
                    Console.WriteLine();
                }
            }
    }
}
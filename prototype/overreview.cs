using System;
using System.Collections.Generic;

public static class info {
    public static void overreview(List<string> tasks)
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
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
    }
}
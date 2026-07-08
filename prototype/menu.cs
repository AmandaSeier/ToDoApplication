using System;
using System.Collections.Generic;

public static class Menu
{
    public static void PrintMenu()
    {
        Console.WriteLine("\n----- TO-DO PROGRAM -----\n");
        Console.WriteLine("1. Add task");
        Console.WriteLine("2. Show current tasks");
        Console.WriteLine("3. Add property to task");
        Console.WriteLine("4. Mark a task done");
        Console.WriteLine("5. Show finished tasks");
        Console.WriteLine("6. Quit\n");
        Console.WriteLine("Choose 1, 2, 3 or 4: ");
        Console.WriteLine();
    }
}
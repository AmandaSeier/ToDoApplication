using System;
using System.Collections.Generic;

public static class Info {
    public static void Overview(List<ToDoTask> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("You have no current tasks added!");
            return;
        }
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine("Your tasks: ");
            tasks[i].ShowTask();            
        }
    }

    public static void FinishedOverview(List<ToDoTask> finishedTasks)
    {
        if (finishedTasks.Count == 0)
        {
            Console.WriteLine("You haven't completed any tasks yet.");
            return;
        }

        for (int i = 0; i < finishedTasks.Count; i++)
        {
            Console.WriteLine("Tasks completed: ");
            finishedTasks[i].ShowTask();
        }
    }
}
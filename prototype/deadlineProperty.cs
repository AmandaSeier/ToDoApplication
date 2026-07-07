using System;
using System.Collections.Generic;

public class DeadlineProperty : Property
{
    public DateTime Deadline
    {
        get;
        set;
    }

    public DeadlineProperty(string name, DateTime deadline) : base(name)
    {
        Deadline = deadline;
    }

    public override void ShowProperty()
    {
        Console.WriteLine($"{Name}: {Deadline:dd-MM-yyyy}");
    }
}

using System;
using System.Collections.Generic;

public class DeadlineProperty : Property
{
    public DateTime Deadline 
    { 
        get; 
        set; 
    }

    public DeadlineProperty(DateTime deadline) : base("Deadline")
    {
        Deadline = deadline;
    }

    public override void ShowProperty()
    {
        Console.WriteLine($"{Name}: {Deadline: dd-MM-yyyy}");
    }
}
namespace ToDoApplication.Models.properties;
using System;
using System.Collections.Generic;

public class PriorityProperty : Property
{
    public PriorityLevel Level
    {
        get;
        set;
    }

    public enum PriorityLevel 
    { 
        Low, Medium, High,
    }

    public PriorityProperty(PriorityLevel level) : base("Priority")
    {
        Level = level;
    }

    public override void ShowProperty()
    {
        Console.WriteLine($"{Name}: {Level}");
    }
}
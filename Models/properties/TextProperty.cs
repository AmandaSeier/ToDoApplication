namespace ToDoApplication.Models.properties;
using System;
using System.Collections.Generic;

public class TextProperty : Property
{
    public string Value
    {
        get;
        set;
    }

    public TextProperty(string name, string value) : base(name)
    {
        Value = value;
    }

    public override void ShowProperty()
    {
        Console.WriteLine($"- {Name}: {Value}");
    }
} 
using System;
using System.Collections.Generic;

public class ToDoTask
{
    public string Title
    {
        get;
        set;
    }

    public string Text
    {
        get;
        set;
    }

    public bool IsDone
    {
        get;
        set;
    }

    private List<Property> _properties = new List<Property>();

    public ToDoTask(string title, string text)
    {
        Title = title;
        Text = text;
    }

    public void AddProperty(Property property)
    {
        _properties.Add(property);
    }

    public void ShowTask()
    {
        Console.WriteLine($"Task: {Title}");
        Console.WriteLine($"Description: {Text}");

        if (_properties.Count == 0)
        {
            Console.WriteLine("No current properties added yet.");
        }
        else
        {
            Console.WriteLine("Properties: ");
            for (int i = 1; i < _properties.Count; i++)
            {
                _properties[i].ShowProperty();
            }
        }
    }

    public void CompleteTask()
    {
        IsDone = true;
    }

}
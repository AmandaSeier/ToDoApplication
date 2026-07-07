using System;
using System.Collections.Generic;

public abstract class Property
{
    public string Name
    {
        get;
        set;
    }

    protected Property(string name)
    {
        Name = name;
    }

    public abstract void ShowProperty();
}
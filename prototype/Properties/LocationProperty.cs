using System;
using System.Collections.Generic;

public class LocationProperty : Property
{
    public string Location 
    { 
        get; 
        set; 
    }

    public LocationProperty(string location) : base("Location")
    {
        Location = location;
    }

    public override void ShowProperty()
    {
        Console.WriteLine($"{Name}: {Location}");
    }
}
namespace ToDoApplication.Models;
using System;
using System.Collections.Generic;

public class Member
{
    public string Name
    {
        get;
        set;
    }

    public Member(string name)
    {
        Name = name;
    }
}
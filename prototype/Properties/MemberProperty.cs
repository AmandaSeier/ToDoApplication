using System;
using System.Collections.Generic;

public class MemberProperty : Property
{
    public Member AssignedMember
    {
        get;
        set;
    }

    public MemberProperty(Member member) : base("Assigned member")
    {
        AssignedMember = member;
    }

    public override void ShowProperty()
    {
        Console.WriteLine($"{Name}: {AssignedMember.Name}");
    }
}
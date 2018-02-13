using System;
using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> familyMembers;

    public List<Person> FamilyMembers { get { return this.familyMembers; } }

    public Family()
    {
        this.familyMembers = new List<Person>();
    }
    public void AddMember(Person member)
    {
        this.familyMembers.Add(member);
    }
    public Person GetOldestMember()
    {
        return this.familyMembers.OrderByDescending(x => x.Age).FirstOrDefault();
    }
    public void PrintMembersAboveThirty()
    {
        foreach (var member in this.FamilyMembers
            .Where(x => x.Age > 30)
            .OrderBy(x => x.Name))
        {
            Console.WriteLine(member);
        }
    }
}


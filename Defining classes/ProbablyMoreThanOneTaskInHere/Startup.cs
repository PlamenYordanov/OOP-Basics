using System;

public class Startup
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var family = new Family();
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            var personName = input[0];
            var personAge = int.Parse(input[1]);
            var member = new Person(personName, personAge);
            family.AddMember(member);
        }

        family.PrintMembersAboveThirty();
    }
    
}


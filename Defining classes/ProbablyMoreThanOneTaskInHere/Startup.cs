using System;

public class Startup
{
    public static void Main()
    {
        string firstDate = Console.ReadLine();
        string secondDate = Console.ReadLine();
        var dateDiff = new DateModifier();
        Console.WriteLine(dateDiff.Difference(firstDate, secondDate));
    }
    
}


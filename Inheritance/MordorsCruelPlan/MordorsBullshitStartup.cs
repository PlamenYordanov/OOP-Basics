using System;
using System.Collections.Generic;
using System.Linq;

public class MordorsBullshitStartup
{
    public static void Main()
    {
        var food = Console.ReadLine().Split().ToList();
        var totalHappiness = GetAllFood(food);
        var mood = MoodFactory.GetMood(totalHappiness);
        Console.WriteLine(totalHappiness);
        Console.WriteLine(mood.ToString());

    }
    private static int GetAllFood(List<string> food)
    {
        int total = 0;
        foreach (var item in food)
        {
            total += FoodFactory.GetFood(item).HappinessPoints;
        }
        return total;
    }

}


﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

public class AnimalFarmStartup
{
    public static void Main()
    {

        try
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Chicken chicken = new Chicken(name, age);
            Console.WriteLine(
                "Chicken {0} (age {1}) can produce {2} eggs per day.",
                chicken.Name,
                chicken.Age,
                chicken.GetProductPerDay());
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}


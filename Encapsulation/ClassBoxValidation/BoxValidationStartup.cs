using System;
using System.Linq;
using System.Reflection;

public class BoxValidationStartup
{
    public static void Main()
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double height = double.Parse(Console.ReadLine());

        var box = new Box(length, width, height);

        if (IsZeroOrNegative(length)
            || IsZeroOrNegative(width)
            || IsZeroOrNegative(height))
        {
            return;
        }

        Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
        Console.WriteLine($"Lateral Surface Area - {box.LiteralSurfaceArea():F2}");
        Console.WriteLine($"Volume - {box.Volume():F2}");
    }
    public static bool IsZeroOrNegative(double number)
    {
        return number == 0 || number < 0;
    }
}



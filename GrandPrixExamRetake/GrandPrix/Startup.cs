public class Startup
{
    public static void Main()
    {
        var tyre = new UltrasoftTyre(10, 20);
        tyre.Degrade();
        tyre.Degrade();
        tyre.Degrade();
        tyre.Degrade();
        System.Console.WriteLine(tyre.Degradation);
    }
}


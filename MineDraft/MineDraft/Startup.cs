using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        var draftManager = new DraftManager();
        while (true)
        {
                var input = Console.ReadLine()
                .Split(new[] { ' ' }
                , StringSplitOptions.RemoveEmptyEntries);

                var command = input[0];
                var arguments = input.Skip(1).ToList();
                bool issuedShutdown = false;
                switch (command)
                {
                    case "RegisterHarvester":
                        Console.WriteLine(draftManager.RegisterHarvester(arguments));
                        break;
                    case "RegisterProvider":
                        Console.WriteLine(draftManager.RegisterProvider(arguments));
                        break;
                    case "Day":
                        Console.WriteLine(draftManager.Day());
                        break;
                    case "Mode":
                        Console.WriteLine(draftManager.Mode(arguments));
                        break;
                    case "Check":
                        Console.WriteLine(draftManager.Check(arguments));
                        break;
                    case "Shutdown":
                        Console.WriteLine(draftManager.ShutDown());
                    return;
                    default:
                        break;
                }
        }
    }
}


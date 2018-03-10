using System;
using System.Linq;
using System.Text;

public class Engine
{
    public void Run()
    {
        var commandManager = new CommandManager();

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "Paw Paw Pawah")
        {
            var inputData = input
                .Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
            var command = inputData[0];
            var name = string.Empty;
            if (command != "CastrationStatistics")
            {
                name = inputData[1];
            }
            switch (command)
            {
                case "RegisterAdoptionCenter":
                case "RegisterCleansingCenter":
                case "RegisterCastrationCenter":
                    commandManager.RegisterCenter(command, name);
                    break;
                case "RegisterDog":
                case "RegisterCat":
                    commandManager.RegisterAnimal(inputData);
                    break;
                case "SendForCleansing":
                    commandManager.SendForCleansing(name, inputData[2]);
                    break;
                case "Cleanse":
                    commandManager.Cleanse(name);
                    break;
                case "Adopt":
                    commandManager.Adopt(name);
                    break;
                case "SendForCastration":
                    commandManager.SendForCastration(name, inputData[2]);
                    break;
                case "Castrate":
                    commandManager.Castrate(name);
                    break;
                case "CastrationStatistics":
                    Console.WriteLine(commandManager.PrintCastrated());
                    break;
                default:
                    break;
            }
        }
        var adoptedAnimals = commandManager.AdoptedAnimals.Any() ?
            $"{ string.Join(", ", commandManager.AdoptedAnimals.OrderBy(x => x.Name))}" : "None";
        var cleansedAnimals = commandManager.CleansedAnimals.Any() ?
            $"{string.Join(", ", commandManager.CleansedAnimals.OrderBy(x => x.Name))}" : "None";

        var result = new StringBuilder();
        result.AppendLine($"Paw Incorporative Regular Statistics");
        result.AppendLine($"Adoption Centers: {commandManager.AdoptionCentersCount}");
        result.AppendLine($"Cleansing Centers: {commandManager.CleansingCentersCount}");
        result.AppendLine($"Adopted Animals: {adoptedAnimals}");
        result.AppendLine($"Cleansed Animals: {cleansedAnimals}");
        result.AppendLine($"Animals Awaiting Adoption: {commandManager.AnimalsAwaitingAdoption}");
        result.AppendLine($"Animals Awaiting Cleansing: {commandManager.AnimalsAwaitingCleansing}");
        Print(result.ToString().TrimEnd());

    }
    private void Print(string result)
    {
        Console.WriteLine(result);
    }
    
}


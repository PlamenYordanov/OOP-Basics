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
            var name = inputData[1];
            switch (command)
            {
                case "RegisterAdoptionCenter":
                    commandManager.RegisterAdoptionCenter(name);
                    break;
                case "RegisterCleansingCenter":
                    commandManager.RegisterCleansingCenter(name);
                    break;
                case "RegisterDog":
                    RegisterDog(commandManager, inputData, name);
                    break;
                case "RegisterCat":
                    RegisterCat(commandManager, inputData, name);
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
                default:
                    break;
            }
        }
        var adoptedAnimals = commandManager.AdoptedAnimals.Any() ?
            $"{ string.Join(", ", commandManager.AdoptedAnimals.OrderBy(x => x.Name))}" : "none";
        var cleansedAnimals = commandManager.CleansedAnimals.Any() ?
            $"{string.Join(", ", commandManager.CleansedAnimals.OrderBy(x => x.Name))}" : "none";

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
    private static void RegisterDog(CommandManager commandManager, string[] inputData, string name)
    {
        int age = int.Parse(inputData[2]);
        int learnedCommands = int.Parse(inputData[3]);
        string adoptionCenterName = inputData[4];
        commandManager.RegisterDog(name, age, learnedCommands, adoptionCenterName);
    }
    private static void RegisterCat(CommandManager commandManager, string[] inputData, string name)
    {
        int age = int.Parse(inputData[2]);
        int inteligence = int.Parse(inputData[3]);
        string adoptionCenterName = inputData[4];
        commandManager.RegisterCat(name, age, inteligence, adoptionCenterName);
    }
}


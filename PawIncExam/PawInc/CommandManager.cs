using System.Collections.Generic;
using System.Linq;

public class CommandManager
{
    public CommandManager()
    {
        Centers = new List<Center>();
    }
    public List<Center> Centers { get; private set; }

    public int CleansingCentersCount => Centers.Where(x => x is CleansingCenter).Count();

    public int AdoptionCentersCount => Centers.Where(x => x is AdoptionCenter).Count();

    public int AnimalsAwaitingAdoption => Centers.Where(c => c is AdoptionCenter)
        .Sum(x => x.StoredAnimals
                            .Where(a => a.CleansingStatus == CleansingStatus.Cleansed)
                            .Count());

    public int AnimalsAwaitingCleansing => Centers.Where(s => s is CleansingCenter)
        .Sum(x => x.StoredAnimals
                            .Where(a => a.CleansingStatus == CleansingStatus.Uncleansed)
                            .Count());

    public List<Animal> AdoptedAnimals { get; set; } = new List<Animal>();

    public List<Animal> CleansedAnimals { get; set; } = new List<Animal>();

    public void RegisterCleansingCenter(string name)
    {
        Centers.Add(new CleansingCenter(name));
    }
    public void RegisterAdoptionCenter(string name)
    {
        Centers.Add(new AdoptionCenter(name));
    }
    public void RegisterDog(string name, int age, int learnedCommands, string adoptionCenterName)
    {
        var center = Centers.SingleOrDefault(x => x.Name == adoptionCenterName);
        center.StoredAnimals.Add(new Dog(name, age, learnedCommands));
    }
    public void RegisterCat(string name, int age, int intelligenceCoefficient, string adoptionCenterName)
    {
        var center = Centers.SingleOrDefault(x => x.Name == adoptionCenterName);
        center.StoredAnimals.Add(new Cat(name, age, intelligenceCoefficient));
    }
    public void SendForCleansing(string adoptionCenterName, string cleansingCenterName )
    {
        var adoptionCenter = Centers.SingleOrDefault(x => x.Name == adoptionCenterName);
        var cleansingCenter = Centers.SingleOrDefault(x => x.Name == cleansingCenterName);
        var uncleansedAnimals = adoptionCenter.StoredAnimals.Where(x => x.CleansingStatus == CleansingStatus.Uncleansed);
        cleansingCenter.StoredAnimals.AddRange(uncleansedAnimals);
        
    }
    public void Cleanse(string cleansingCenterName)
    {
        var cleansingCenter = (CleansingCenter)Centers.SingleOrDefault(x => x.Name == cleansingCenterName);
        cleansingCenter.CleanseAnimals();
        CleansedAnimals.AddRange(cleansingCenter.StoredAnimals);
        cleansingCenter.StoredAnimals.Clear();
    }
    public void Adopt(string adoptionCenterName)
    {
        var adoptionCenter = (AdoptionCenter)Centers.SingleOrDefault(x => x.Name == adoptionCenterName);
        AdoptedAnimals.AddRange(adoptionCenter.Adopt());
    }
}


using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CommandManager
{
    public CommandManager()
    {
        Centers = new List<Center>();
    }
    public List<Center> Centers { get; private set; }

    public int CleansingCentersCount => Centers.Where(x => x is CleansingCenter).Count();

    public int AdoptionCentersCount => Centers.Where(x => x is AdoptionCenter).Count();

    public int CastrationCentersCount => Centers.Where(x => x is CastrationCenter).Count();

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

    public List<Animal> CastratedAnimals { get; set; } = new List<Animal>();

    public void RegisterCenter(string type, string name)
    {
        Centers.Add(CenterFactory.Create(type, name));
    }
    
    public void RegisterAnimal(string[] inputData)
    {
        var adoptionCenterName = inputData[4];
        var center = Centers.SingleOrDefault(x => x.Name == adoptionCenterName);
        center.StoredAnimals.Add(AnimalFactory.Create(inputData));
    }

    public void SendForCleansing(string adoptionCenterName, string cleansingCenterName)
    {
        var adoptionCenter = Centers.SingleOrDefault(x => x.Name == adoptionCenterName);
        var cleansingCenter = Centers.SingleOrDefault(x => x.Name == cleansingCenterName);
        var uncleansedAnimals = adoptionCenter.StoredAnimals
            .Where(x => x.CleansingStatus == CleansingStatus.Uncleansed
                    && !cleansingCenter.StoredAnimals.Contains(x));
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

    public void SendForCastration(string adoptionCenterName, string castrationCenterName)
    {
        var adoptionCenter = Centers.SingleOrDefault(x => x.Name == adoptionCenterName);
        var castrationCenter = Centers.SingleOrDefault(x => x.Name == castrationCenterName);
        castrationCenter.StoredAnimals.AddRange(adoptionCenter.StoredAnimals);
    }

    public void Castrate(string castrationCenterName)
    {
        var castrationCenter = (CastrationCenter)Centers.SingleOrDefault(x => x.Name == castrationCenterName);
        castrationCenter.CastrateAnimals();
        CastratedAnimals.AddRange(castrationCenter.StoredAnimals);
        castrationCenter.StoredAnimals.Clear();
    }

    public string PrintCastrated()
    {
        var castratedAnimals = CastratedAnimals.Any() ? 
            $"{string.Join(", ", CastratedAnimals.OrderBy(x => x.Name))}" 
            : "None";
        var sb = new StringBuilder();
        sb.AppendLine($"Paw Inc. Regular Castration Statistics");
        sb.AppendLine($"Castration Centers: {CastrationCentersCount}");
        sb.AppendLine($"Castrated Animals: {castratedAnimals}");

        return sb.ToString().TrimEnd();
    }
}


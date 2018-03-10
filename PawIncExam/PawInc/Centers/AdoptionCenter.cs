
using System.Collections.Generic;
using System.Linq;

public class AdoptionCenter : Center
{
    public  AdoptionCenter(string name) 
        : base(name)
    {
    }
    public IEnumerable<Animal> Adopt()
    {
        var adoptedAnimals = StoredAnimals.Where(x => x.CleansingStatus == CleansingStatus.Cleansed).ToList();
        StoredAnimals.RemoveAll(x => x.CleansingStatus == CleansingStatus.Cleansed);
        return adoptedAnimals;
    }
}


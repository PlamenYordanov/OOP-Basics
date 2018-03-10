using System.Linq;

public class CleansingCenter : Center
{
    public CleansingCenter(string name)
        : base(name)
    {
    }
    public void CleanseAnimals()
    {
        StoredAnimals.ForEach(x => x.Cleance());
    }

}



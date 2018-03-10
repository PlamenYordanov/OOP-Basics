public class CastrationCenter : Center
{
    public CastrationCenter(string name)
        : base(name)
    {
    }

    public void CastrateAnimals()
    {
        StoredAnimals.ForEach(x => x.Castrate());
    }
}


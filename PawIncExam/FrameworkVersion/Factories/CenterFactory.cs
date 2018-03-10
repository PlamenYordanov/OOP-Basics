public class CenterFactory
{
    public static Center Create(string type, string name)
    {
        switch (type)
        {
            case "RegisterAdoptionCenter":
                return new AdoptionCenter(name);
            case "RegisterCleansingCenter":
                return new CleansingCenter(name);
            default:
                return new CastrationCenter(name);
        }
    }
}


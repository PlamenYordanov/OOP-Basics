public abstract class Food
{

    public int HappinessPoints { get; private set; }

    public Food(int happinessPoints)
    {
        HappinessPoints = happinessPoints;
    }
}


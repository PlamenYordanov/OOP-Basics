public class FoodFactory
{
    public static Food GetFood(string food)
    {
        switch (food.ToLower())
        {
            case "apple":
                return new Apple();
            case "melon":
                return new Melon();
            case "cram":
                return new Cram();
            case "lembas":
                return new Lembas();
            case "honeycake":
                return new HoneyCake();
            case "mushrooms":
                return new Mushroom();
            default:
                return new OtherFood();
        }
    }
}


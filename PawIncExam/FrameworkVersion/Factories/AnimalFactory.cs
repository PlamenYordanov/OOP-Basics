public class AnimalFactory
{
    public static Animal Create(string[] inputData)
    {
        var type = inputData[0];
        var name = inputData[1];
        var age = int.Parse(inputData[2]);
        var specialAttribute = int.Parse(inputData[3]);
        switch (type)
        {
            case "RegisterDog":
                return new Dog(name, age, specialAttribute);
            default:
                return new Cat(name, age, specialAttribute);
        }
    }
}


public class Dog : Animal
{
    public Dog(string name, int age, int ammountOfCommands) 
        : base(name, age)
    {
        AmmountOfCommands = ammountOfCommands;
    }

    public int AmmountOfCommands { get; protected set; }
}


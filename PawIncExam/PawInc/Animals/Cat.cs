public class Cat : Animal
{
    public  Cat(string name, int age, int intelligenceCoefficient) 
        : base(name, age)
    {
        IntelligenceCoefficient = intelligenceCoefficient;
    }
    public int IntelligenceCoefficient { get; protected set; }
}


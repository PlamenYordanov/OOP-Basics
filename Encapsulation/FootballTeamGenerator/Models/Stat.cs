public class Stat
{
    private int value = -1;
    private string name;

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            this.name = value;
        }
    }

    public int Value
    {
        get { return this.value; }
        private set
        {
            if(value < 0 || value > 100)
            {
                System.Console.WriteLine($"{this.name} should be between 0 and 100.");
                return;
            }
            this.value = value;
        }
        
    }
    
    public Stat(int value, string name)
    {
        Name = name;
        Value = value;
    }

}
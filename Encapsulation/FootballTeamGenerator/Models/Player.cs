public class Player : INamable
{
    private string name;

    public Stat Endurance { get; private set; }
    public Stat Spirit { get; private set; }
    public Stat Dribble { get; private set; }
    public Stat Passing { get; private set; }
    public Stat Shooting { get; private set; }

    public string Name
    {
        get { return this.name; }

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                System.Console.WriteLine("A name should not be empty.");
                return;
            }
            this.name = value;
        }
    }
    public double Stats =>  (Endurance.Value +
                            Spirit.Value +
                            Dribble.Value +
                            Passing.Value +
                            Shooting.Value) / 5.0;

    public Player(string name, int endurance, int spirit, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = new Stat(endurance, nameof(Endurance));
        this.Spirit = new Stat(spirit, nameof(Spirit));
        this.Dribble = new Stat(dribble, nameof(Dribble));
        this.Passing = new Stat(passing, nameof(Passing));
        this.Shooting = new Stat(shooting, nameof(Shooting));
    }
    public Player(string name)
    {
        Name = name;
    }

    public bool IsValid()
    {
        return Endurance.Value != -1 &&
                Spirit.Value != -1 &&
                Dribble.Value != -1 &&
                Passing.Value != -1 &&
                Shooting.Value != -1;
    }
}
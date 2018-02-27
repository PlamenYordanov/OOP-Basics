public class Song
{
    private string artist;
    private string name;
    private int minutes;
    private int seconds;

    public string  Artist
    {
        get { return this.artist; }

        private set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }
            this.artist = value;
        }
    }
    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }
            this.name = value;
        }
    }
    public int Minutes
    {
        get { return this.minutes; }
        private set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }
            this.minutes = value;
        }
    }
    public int Seconds
    {
        get { return this.seconds; }
        private set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }
            this.seconds = value;
        }
    }
    public Song(string artist, string name, int minutes, int seconds)
    {
        Artist = artist;
        Name = name;
        Minutes = minutes;
        Seconds = seconds;
    }
    public int TotalSeconds()
    {
        return Seconds + Minutes * 60;
    }
}


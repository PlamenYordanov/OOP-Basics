public class MoodFactory
{
    public static Mood GetMood(int happiness)
    {
        if (happiness < -5)
        {
            return Mood.Angry;
        }
        else if (happiness < 1)
        {
            return Mood.Sad;
        }
        else if (happiness < 16)
        {
            return Mood.Happy;
        }
        else
        {
            return Mood.JavaScript;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        var songDatabase = new List<Song>();

        for (int i = 0; i < n; i++)
        {
            try
            {
                
                var songData = Console.ReadLine()
                   .Split(new[] { ';', ':' }
               , StringSplitOptions.RemoveEmptyEntries);

                bool isValidSong = songData.Length == 4;

                if (!isValidSong )
                {
                    throw new InvalidSongException();
                }
                var artist = songData[0];
                var name = songData[1];
                var minutes = int.Parse(songData[2]);
                var seconds = int.Parse(songData[3]);

                var song = new Song(artist, name, minutes, seconds);
                songDatabase.Add(song);
                Console.WriteLine($"Song added.");
            }
            catch (InvalidSongException ise)
            {
                Console.WriteLine(ise.Message);
            }
        }
        Console.WriteLine($"Songs added: {songDatabase.Count}");
        Console.WriteLine($"Playlist length: {FormatLength(songDatabase)}");
    }
    private static long TotalLengthInSeconds(List<Song> songDatabase)
    {
        return songDatabase.Sum(x => x.TotalSeconds());
    }
    private static string FormatLength(List<Song> songDatabase)
    {
        var totalLength = TimeSpan.FromSeconds(TotalLengthInSeconds(songDatabase));

        return $"{totalLength.Hours}h {totalLength.Minutes}m {totalLength.Seconds}s";
    }
}


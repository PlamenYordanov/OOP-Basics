using System;

public abstract class Figure
{
    public int Width { get; set; }

    public Figure(int width)
    {
        this.Width = width;
    }

    public virtual void Draw(int height)
    {
        Console.WriteLine("{0}{1}{0}", "|"
            ,new string('-', this.Width));
        for (int i = 0; i < height - 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", "|"
            , new string(' ', this.Width));
        }
        Console.WriteLine("{0}{1}{0}", "|"
            , new string('-', this.Width));
    }
}


using System;
public class DrawingToolStartup
{
    public static void Main()
    {
        var input = Console.ReadLine();
        Figure figure = null;

        switch (input.ToLower())
        {
            case "square":
                int width = int.Parse(Console.ReadLine());
                figure = new Square(width);
                break;
            case "rectangle":
                int rWidth = int.Parse(Console.ReadLine());
                int rHeight = int.Parse(Console.ReadLine());
                figure = new Rectangle(rWidth, rHeight);
                break;
            default:
                break;
        }
        var tool = new DrawingTool(figure);
        tool.Draw();
    }
}


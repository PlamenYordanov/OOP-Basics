using System;
using System.Collections.Generic;
using System.Linq;

public class RectangleIntersectionStartup
{
    public static void Main()
    {
        var nAndM = Console.ReadLine().Split();
        int n = int.Parse(nAndM[0]);
        int m = int.Parse(nAndM[1]);
        
        var rectangles = new List<Rectangle>();
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            string id = input[0];
            int width = int.Parse(input[1]);
            int height = int.Parse(input[2]);
            int x = int.Parse(input[3]);
            int y = int.Parse(input[4]);
            var rectangle = new Rectangle(id, width, height, new Point(x, y));
            rectangles.Add(rectangle);

        }
        
        for (int i = 0; i < m; i++)
        {
            var input = Console.ReadLine().Split();
            var thisRectangle = rectangles.SingleOrDefault(r => r.Id == input[0]);
            var otherRectangle = rectangles.SingleOrDefault(r => r.Id == input[1]);
            Console.WriteLine(thisRectangle.IsIntersected(otherRectangle).ToString().ToLower());
        }

    }
}


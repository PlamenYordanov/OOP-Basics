public class Rectangle
{
    public string Id { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public Point Point { get; set; }
    public Rectangle(string id, int width, int height, Point point)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.Point = point;
    }
    public bool IsIntersected(Rectangle other)
    {
        if (this.Point.Y + this.Width < other.Point.Y
            || other.Point.Y + other.Width < this.Point.Y
            || this.Point.X + Height < other.Point.X
            || other.Point.X + Height < this.Point.X)
        {
            return false;
        }
        return true;
    }
}


public class Rectangle : Figure
{
    public int Height { get; set; }

    public Rectangle(int width, int height) 
        : base(width)
    {
        this.Height = height;
    }
    public override void Draw(int height)
    {
        base.Draw(this.Height);
    }
}


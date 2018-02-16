public class Square : Figure
{
    public Square(int width)
        : base(width)
    { }

    public override void Draw(int height)
    {
        base.Draw(this.Width);
    }
}


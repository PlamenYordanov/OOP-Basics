public class DrawingTool
{
    public Figure Figure { get; set; }

    public DrawingTool(Figure figure)
    {
        this.Figure = figure;
    }
    public void Draw()
    {
        switch (Figure)
        {
            case Square s:
                s.Draw(s.Width);
                break;
            case Rectangle r:
                r.Draw(r.Height);
                break;
            default:
                break;
        }
    }
}


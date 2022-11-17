namespace Rectangles.Challenge.Console.Models;

public class Rectangle
{
    public Line BottomLine { get; set; }
    public Line RightLine  { get; set; }
    public Line TopLine  { get; set; }
    public Line LeftLine  { get; set; }
    public Point TopLeft { get; }
    public Point BottomLeft { get; }
    public Point TopRight { get; }
    public Point BottomRight { get; }
    public Size Size { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bottomLeft"></param>
    /// <param name="size"></param>
    /// <exception cref="ArgumentException"></exception>
    public Rectangle(Point bottomLeft, Size size)
    {
        if (size.Width <= 0)
        {
            throw new ArgumentException($"{nameof(Size.Width)} cannot be less or equal than zero");
        }
        if (size.Height <= 0)
        {
            throw new ArgumentException($"{nameof(Size.Height)} cannot be less or equal than zero");
        }

        Size = size;
        BottomLeft = bottomLeft;
        TopLeft = BottomLeft with {Y = bottomLeft.Y + Size.Height};
        TopRight = new Point(BottomLeft.X + Size.Width, bottomLeft.Y + Size.Height);
        BottomRight = BottomLeft with {X = BottomLeft.X + Size.Width};
        
        BottomLine = new HorizontalLine(BottomLeft, BottomRight);
        RightLine = new VerticalLine(BottomRight, TopRight);
        TopLine = new HorizontalLine(TopLeft, TopRight);
        LeftLine = new VerticalLine(BottomLeft, TopLeft);
    }

    public bool Contains(Point point)
    {
        return point.X >= BottomLeft.X && point.X <= BottomRight.X && 
               point.Y >= BottomLeft.Y && point.Y <= TopLeft.Y;
    }

    public IEnumerable<HorizontalLine> GetHorizontalLines()
    {
        yield return new HorizontalLine(TopLeft, TopRight);
        yield return new HorizontalLine(BottomLeft, BottomRight);
    }
    
    public IEnumerable<VerticalLine> GetVerticalLines()
    {
        yield return new VerticalLine(BottomLeft, TopLeft);
        yield return new VerticalLine(BottomRight, TopRight);
    }
}
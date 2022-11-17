namespace Rectangles.Challenge.Core.Models;

public class Rectangle
{
    private readonly Point _topLeft;
    private readonly Point _topRight;
    private readonly Point _bottomRight;

    /// <summary>
    /// Represent Source Point (X, Y)
    /// </summary>
    public Point BottomLeft { get; }
    
    /// <summary>
    /// Indicates Width and Height
    /// </summary>
    public Size Size { get; }

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
        _topLeft = BottomLeft with {Y = bottomLeft.Y + Size.Height};
        _topRight = new Point(BottomLeft.X + Size.Width, bottomLeft.Y + Size.Height);
        _bottomRight = BottomLeft with {X = BottomLeft.X + Size.Width};
    }

    public HorizontalLine GetBottomLine() => new(BottomLeft, _bottomRight);
    public HorizontalLine GetTopLine() => new(_topLeft, _topRight);
    public VerticalLine GetLeftLine() => new(BottomLeft, _topLeft);
    public VerticalLine GetRightLine() => new(_bottomRight, _topRight);

    public IEnumerable<HorizontalLine> GetHorizontalLines()
    {
        yield return GetBottomLine();
        yield return GetTopLine();
    }
    
    public IEnumerable<VerticalLine> GetVerticalLines()
    {
        yield return GetLeftLine();
        yield return GetRightLine();
    }
}
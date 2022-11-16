namespace Rectangles.Challenge.Console.Models;

public record Line(Point Start, Point End);
public record VerticalLine(Point Start, Point End) : Line(Start, End);
public record HorizontalLine : Line
{
    public HorizontalLine(Point start, Point end) : base(start, end)
    {
        if (start.Y != end.Y)
        {
            // [GR - Create Constants for.
            throw new ArgumentException("Not valid points");
        }
    }
    
    public bool IntersectWith(VerticalLine line)
    {
        return IsBetweenRange(Start.X, End.X, line.Start.X) &&
               IsBetweenRange(line.Start.Y, line.End.Y, Start.Y);
    }
    
    public Point? IntersectionPoint(VerticalLine line)
    {
        return !IntersectWith(line) ? default : new Point(line.Start.X, Start.Y);
    }

    private static bool IsBetweenRange(int startLimit, int endLimit, int limit)
    {
        return startLimit <= limit && limit <= endLimit;
    }
}

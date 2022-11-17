namespace Rectangles.Challenge.Core.Models;

public record Line(Point Start, Point End);

public record VerticalLine : Line
{
    /// <summary>
    /// Represents a VerticalLine.
    /// </summary>
    /// <param name="start">Start <see cref="Point"/> (Bottom point)</param>
    /// <param name="end">End <see cref="Point"/> (Top point)</param>
    public VerticalLine(Point start, Point end) : base(start, end)
    {
        if (start.X != end.X)
        {
            throw new ArgumentException($"Coordinate {nameof(start.X)} not valid. Start and End points must have same {nameof(start.X)} axis.");
        }
    }
}

public record HorizontalLine : Line
{
    /// <summary>
    /// Represents a HorizontalLine.
    /// </summary>
    /// <param name="start">Start <see cref="Point"/> (Left point)</param>
    /// <param name="end">End <see cref="Point"/> (Right point)</param>
    public HorizontalLine(Point start, Point end) : base(start, end)
    {
        if (start.Y != end.Y)
        {
            throw new ArgumentException($"Coordinate {nameof(start.Y)} not valid. Start and End points must have same {nameof(start.Y)} axis.");
        }
    }
    
    /// <summary>
    /// Checks if an intersection exists with a <see cref="VerticalLine"/>
    /// </summary>
    /// <param name="line">An instance of <see cref="VerticalLine"/> to evaluate.</param>
    /// <returns>True if exists an intersection between the two lines.</returns>
    public bool IntersectWith(VerticalLine line)
    {
        return IsBetweenRange(Start.X, End.X, line.Start.X) &&
               IsBetweenRange(line.Start.Y, line.End.Y, Start.Y);
    }
    
    /// <summary>
    /// Checks if an intersection exists. If so, returns the intersection <see cref="Point"/>.
    /// </summary>
    /// <param name="line">An instance of <see cref="VerticalLine"/> to evaluate.</param>
    /// <returns>A <see cref="Point"/> that represents intersection.</returns>
    public Point? IntersectionPoint(VerticalLine line)
    {
        return !IntersectWith(line) ? default : new Point(line.Start.X, Start.Y);
    }

    private static bool IsBetweenRange(int startLimit, int endLimit, int limit)
    {
        return startLimit <= limit && limit <= endLimit;
    }
}

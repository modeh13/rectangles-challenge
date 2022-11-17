namespace Rectangles.Challenge.Console.Models;

public record Point(int X, int Y)
{
    public override string ToString()
    {
        return $"({X.ToString()}, {Y.ToString()})";
    }
}
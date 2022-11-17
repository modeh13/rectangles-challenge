using Ardalis.SmartEnum;

namespace Rectangles.Challenge.Console.Models.Enums;

public class ResultType : SmartEnum<ResultType>
{
    public static readonly ResultType Intersection = new(nameof(Intersection), 1);
    public static readonly ResultType NoIntersection = new("No Intersection", 2);
    public static readonly ResultType Containment = new(nameof(Containment), 3);
    public static readonly ResultType NotContainment = new("Not Containment", 4);
    public static readonly ResultType AdjacentSubLine = new("Adjacent (SubLine)", 5);
    public static readonly ResultType AdjacentProper = new("Adjacent (Proper)", 6);
    public static readonly ResultType AdjacentPartial = new("Adjacent (Partial)", 7);
    public static readonly ResultType NotAdjacent = new("Not adjacent", 8);

    private ResultType(string name, int value) : base(name, value) { }
}
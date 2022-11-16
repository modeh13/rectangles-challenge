using Ardalis.SmartEnum;

namespace Rectangles.Challenge.Console.Models.Enums;

public class ResultType : SmartEnum<ResultType>
{
    public static readonly ResultType Intersection = new ResultType(nameof(Intersection), 1);
    public static readonly ResultType NoIntersection = new ResultType("No Intersection", 2);

    private ResultType(string name, int value) : base(name, value) { }
}
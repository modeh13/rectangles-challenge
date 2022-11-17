using Ardalis.SmartEnum;

namespace Rectangles.Challenge.Core.Models.Enums;

public class Algorithm : SmartEnum<Algorithm>
{
    public static readonly Algorithm All = new(nameof(All), 0);
    public static readonly Algorithm Intersection = new(nameof(Intersection), 1);
    public static readonly Algorithm Containment = new(nameof(Containment), 2);
    public static readonly Algorithm Adjacency = new(nameof(Adjacency), 3);

    private Algorithm(string name, int value) : base(name, value) {}
}
using Rectangles.Challenge.Console.Algorithms;
using Rectangles.Challenge.Console.Algorithms.Abstractions;
using Rectangles.Challenge.Console.Models;
using Rectangles.Challenge.Console.Models.Enums;

namespace Rectangles.Challenge.Tests.Algorithms;

public class IntersectionAlgorithmTests
{
    private readonly IRectangleAlgorithm<IntersectionResult> _intersectionAlgorithm;

    public IntersectionAlgorithmTests()
    {
        _intersectionAlgorithm = new IntersectionAlgorithm();
    }

    [Theory]
    [MemberData(nameof(IntersectionTestCases))]
    public void Execute_Returns_Intersection(Rectangle rectangleA, Rectangle rectangleB, List<Point> intersectionPoints)
    {
        // Arrange
        // Act
        var intersectionResult = _intersectionAlgorithm.Execute(rectangleA, rectangleB);

        // Assert
        Assert.NotNull(intersectionResult);
        Assert.Equal(ResultType.Intersection.Name, intersectionResult.ResultType.Name);
        Assert.NotEmpty(intersectionResult.IntersectionPoints);
        Assert.Equal(intersectionPoints.Count, intersectionResult.IntersectionPoints.Count);
        Assert.Equal(intersectionPoints, intersectionResult.IntersectionPoints);
    }
    
    [Theory]
    [MemberData(nameof(NoIntersectionTestCases))]
    public void Execute_Returns_NoIntersection(Rectangle rectangleA, Rectangle rectangleB)
    {
        // Arrange
        // Act
        var intersectionResult = _intersectionAlgorithm.Execute(rectangleA, rectangleB);

        // Assert
        Assert.NotNull(intersectionResult);
        Assert.Equal(ResultType.NoIntersection.Name, intersectionResult.ResultType.Name);
        Assert.Empty(intersectionResult.IntersectionPoints);
    }

    public static IEnumerable<object[]> IntersectionTestCases()
    {
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(2, 2), new Size(4, 4)),
            new List<Point>
            {
                new(2, 5),
                new(5, 2)
            }
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(2, -2), new Size(4, 4)),
            new List<Point>
            {
                new(2, 0),
                new(5, 2)
            }
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(-2, 2), new Size(4, 4)),
            new List<Point>
            {
                new(0, 2),
                new(2, 5)
            }
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(-2, -2), new Size(4, 4)),
            new List<Point>
            {
                new(0, 2),
                new(2, 0)
            }
        };
    }

    public static IEnumerable<object[]> NoIntersectionTestCases()
    {
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(6, 0), new Size(4, 4))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(0, 6), new Size(4, 4))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(-5, 0), new Size(4, 4))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(0, -5), new Size(4, 4))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(4, 0), new Size(3, 4))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(4, 4), new Size(3, 2))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(0, 4), new Size(2, 2))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(-3, 4), new Size(3, 2))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(-3, 0), new Size(3, 2))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(-3, -2), new Size(3, 2))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(0, -2), new Size(3, 2))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(4, -2), new Size(3, 2))
        };
    }
}
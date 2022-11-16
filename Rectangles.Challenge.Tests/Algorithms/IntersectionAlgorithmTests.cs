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
    public void Check_Returns_Intersection(Rectangle rectangleA, Rectangle rectangleB)
    {
        // Arrange
        // Act
        var intersectionResult = _intersectionAlgorithm.Execute(rectangleA, rectangleB);

        // Assert
        Assert.NotNull(intersectionResult);
        Assert.Equal(ResultType.Intersection.Name, intersectionResult.ResultType.Name);
        Assert.NotEmpty(intersectionResult.IntersectionPoints);
    }

    public static IEnumerable<object[]> IntersectionTestCases => new[]
    {
        new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)), 
            new Rectangle(new Point(2, 2), new Size(4, 4))
        },
        new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)), 
            new Rectangle(new Point(2, -2), new Size(4, 4))
        },
        new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)), 
            new Rectangle(new Point(-2, 2), new Size(4, 4))
        },
        new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)), 
            new Rectangle(new Point(-2, -2), new Size(4, 4))
        }
    };
}
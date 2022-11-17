using Rectangles.Challenge.Core.Algorithms;
using Rectangles.Challenge.Core.Algorithms.Abstractions;
using Rectangles.Challenge.Core.Models;
using Rectangles.Challenge.Core.Models.Enums;

namespace Rectangles.Challenge.Tests.Algorithms;

public class ContainmentAlgorithmTests
{
    private readonly IRectangleAlgorithm<ResultBase> _containmentAlgorithm;

    public ContainmentAlgorithmTests()
    {
        _containmentAlgorithm = new ContainmentAlgorithm();
    }

    [Theory]
    [MemberData(nameof(ContainmentTestCases))]
    public void Execute_Returns_Containment(Rectangle rectangleA, Rectangle rectangleB)
    {
        // Arrange
        // Act
        var resultBase = _containmentAlgorithm.Execute(rectangleA, rectangleB);

        // Assert
        Assert.NotNull(resultBase);
        Assert.Equal(ResultType.Containment.Name, resultBase.ResultType.Name);
    }
    
    [Theory]
    [MemberData(nameof(NotContainmentTestCases))]
    public void Execute_Returns_NotContainment(Rectangle rectangleA, Rectangle rectangleB)
    {
        // Arrange
        // Act
        var resultBase = _containmentAlgorithm.Execute(rectangleA, rectangleB);

        // Assert
        Assert.NotNull(resultBase);
        Assert.Equal(ResultType.NotContainment.Name, resultBase.ResultType.Name);
    }

    public static IEnumerable<object[]> ContainmentTestCases()
    {
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(0, 0), new Size(5, 5))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(0, 0), new Size(3, 3))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(2, 0), new Size(3, 3))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(0, 2), new Size(3, 3))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(2, 2), new Size(3, 3))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(2, 2), new Size(2, 2))
        };
    }
    
    public static IEnumerable<object[]> NotContainmentTestCases()
    {        
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(5, 0), new Size(5, 5))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(0, 5), new Size(5, 5))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(-5, 0), new Size(5, 5))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(0, -5), new Size(5, 5))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(5, -5), new Size(5, 5))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(5, 5), new Size(5, 5))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(-5, 5), new Size(5, 5))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(3, 3), new Size(5, 5))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(-3, 2), new Size(5, 5))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(-3, -2), new Size(5, 5))
        };
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(5, 5)),
            new Rectangle(new Point(3, -2), new Size(5, 5))
        };
    }
}
using Rectangles.Challenge.Core.Algorithms;
using Rectangles.Challenge.Core.Algorithms.Abstractions;
using Rectangles.Challenge.Core.Models;
using Rectangles.Challenge.Core.Models.Enums;

namespace Rectangles.Challenge.Tests.Algorithms;

public class AdjacencyAlgorithmTests
{
    private readonly IRectangleAlgorithm<ResultBase> _adjacencyAlgorithm;

    public AdjacencyAlgorithmTests()
    {
        _adjacencyAlgorithm = new AdjacencyAlgorithm();
    }

    [Theory]
    [MemberData(nameof(AdjacencySubLineTestCases))]
    public void Execute_Returns_AdjacencySubLine(Rectangle rectangleA, Rectangle rectangleB)
    {
        // Arrange
        // Act
        var resultBase = _adjacencyAlgorithm.Execute(rectangleA, rectangleB);
        
        // Assert
        Assert.NotNull(resultBase);
        Assert.Equal(ResultType.AdjacentSubLine.Name, resultBase.ResultType.Name);
    }
    
    [Theory]
    [MemberData(nameof(AdjacencyProperTestCases))]
    public void Execute_Returns_AdjacencyProper(Rectangle rectangleA, Rectangle rectangleB)
    {
        // Arrange
        // Act
        var resultBase = _adjacencyAlgorithm.Execute(rectangleA, rectangleB);
        
        // Assert
        Assert.NotNull(resultBase);
        Assert.Equal(ResultType.AdjacentProper.Name, resultBase.ResultType.Name);
    }
    
    [Theory]
    [MemberData(nameof(AdjacencyPartialTestCases))]
    public void Execute_Returns_AdjacencyPartial(Rectangle rectangleA, Rectangle rectangleB)
    {
        // Arrange
        // Act
        var resultBase = _adjacencyAlgorithm.Execute(rectangleA, rectangleB);
        
        // Assert
        Assert.NotNull(resultBase);
        Assert.Equal(ResultType.AdjacentPartial.Name, resultBase.ResultType.Name);
    }
    
    [Theory]
    [MemberData(nameof(NotAdjacentTestCases))]
    public void Execute_Returns_NotAdjacent(Rectangle rectangleA, Rectangle rectangleB)
    {
        // Arrange
        // Act
        var resultBase = _adjacencyAlgorithm.Execute(rectangleA, rectangleB);
        
        // Assert
        Assert.NotNull(resultBase);
        Assert.Equal(ResultType.NotAdjacent.Name, resultBase.ResultType.Name);
    }

    public static IEnumerable<object[]> AdjacencySubLineTestCases()
    {
        // Case 1 (Adjacency Case 1)
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(4, 1), new Size(4, 2))
        };
        // Case 2
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(4, 0), new Size(4, 2))
        };
        // Case 3
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(1, 4), new Size(2, 2))
        };
        // Case 4
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(0, 4), new Size(2, 2))
        };
        // Case 5
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(-2, 1), new Size(2, 2))
        };
        // Case 6
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(-2, 0), new Size(2, 2))
        };
        // Case 7
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(1, -2), new Size(2, 2))
        };
        // Case 8
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(0, -2), new Size(2, 2))
        };
    }
    
    public static IEnumerable<object[]> AdjacencyProperTestCases()
    {
        // Case 9
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(4, 0), new Size(4, 4))
        };
        // Case 10
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(0, 4), new Size(4, 4))
        };
        // Case 11
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(-4, 0), new Size(4, 4))
        };
        // Case 12
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(0, -4), new Size(4, 4))
        };
    }
    
    public static IEnumerable<object[]> AdjacencyPartialTestCases()
    {
        // Case 13
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(4, 2), new Size(2, 4))
        };
        // Case 14
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(-2, 4), new Size(4, 2))
        };
        // Case 15
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(-2, -2), new Size(2, 4))
        };
        // Case 16
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(2, -2), new Size(4, 2))
        };
        // Case 17
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(4, -2), new Size(2, 4))
        };
        // Case 18
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(2, 4), new Size(4, 2))
        };
        // Case 19
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(-2, 2), new Size(2, 4))
        };
        // Case 20
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(-2, -2), new Size(4, 2))
        };
        // Case 21
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(4, 0), new Size(4, 6))
        };
    }
    
    public static IEnumerable<object[]> NotAdjacentTestCases()
    {
        // Case 22
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(5, 0), new Size(4, 4))
        };
        // Case 23
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(0, 5), new Size(4, 4))
        };
        // Case 24
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(-5, 0), new Size(4, 4))
        };
        // Case 25
        yield return new object[]
        {
            new Rectangle(new Point(0, 0), new Size(4, 4)),
            new Rectangle(new Point(0, -5), new Size(4, 4))
        };
    }
}
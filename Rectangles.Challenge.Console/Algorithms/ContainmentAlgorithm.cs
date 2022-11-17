using Rectangles.Challenge.Console.Algorithms.Abstractions;
using Rectangles.Challenge.Console.Models;
using Rectangles.Challenge.Console.Models.Enums;

namespace Rectangles.Challenge.Console.Algorithms;

public class ContainmentAlgorithm : IRectangleAlgorithm<ResultBase>
{
    public ResultBase Execute(Rectangle rectangleA, Rectangle rectangleB)
    {
        var isRectangleContained = rectangleA.Contains(rectangleB.BottomLeft) &&
                                   rectangleA.Contains(rectangleB.TopLeft) &&
                                   rectangleA.Contains(rectangleB.TopRight) &&
                                   rectangleA.Contains(rectangleB.BottomRight);

        return isRectangleContained ? new ResultBase(ResultType.Containment) : new ResultBase(ResultType.NoContainment);
    }
}
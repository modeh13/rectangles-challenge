using Rectangles.Challenge.Core.Algorithms.Abstractions;
using Rectangles.Challenge.Core.Models;
using Rectangles.Challenge.Core.Models.Enums;

namespace Rectangles.Challenge.Core.Algorithms;

public class ContainmentAlgorithm : IRectangleAlgorithm<ResultBase>
{
    public ResultBase Execute(Rectangle rectangleA, Rectangle rectangleB)
    {
        var isRectangleContained = rectangleA.BottomLeft.X <= rectangleB.BottomLeft.X &&
                                   (rectangleB.BottomLeft.X + rectangleB.Size.Width <= rectangleA.BottomLeft.X + rectangleA.Size.Width) &&
                                   rectangleA.BottomLeft.Y <= rectangleB.BottomLeft.Y &&
                                   (rectangleB.BottomLeft.Y + rectangleB.Size.Height <= rectangleA.BottomLeft.Y + rectangleA.Size.Height);

        return isRectangleContained ? new ResultBase(ResultType.Containment) : new ResultBase(ResultType.NotContainment);
    }
}
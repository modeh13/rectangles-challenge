using Rectangles.Challenge.Console.Algorithms.Abstractions;
using Rectangles.Challenge.Console.Models;
using Rectangles.Challenge.Console.Models.Enums;

namespace Rectangles.Challenge.Console.Algorithms;

public class IntersectionAlgorithm : IRectangleAlgorithm<IntersectionResult>
{
    public IntersectionResult Execute(Rectangle rectangleA, Rectangle rectangleB)
    {
        var intersectionPoints = new List<Point>();

        var rectangleAVersusB = GetIntersectionPoints(rectangleA, rectangleB);
        var rectangleBVersusA = GetIntersectionPoints(rectangleB, rectangleA);
        
        intersectionPoints.AddRange(rectangleAVersusB);
        intersectionPoints.AddRange(rectangleBVersusA);

        return intersectionPoints.Any() ? 
            new IntersectionResult(ResultType.Intersection, intersectionPoints) :
            new IntersectionResult(ResultType.NoIntersection, new List<Point>());
    }

    /// <summary>
    /// Gets Intersection points based on Horizontal and Vertical lines. 
    /// </summary>
    /// <remarks>
    /// Evaluates for each Horizontal line if it's intercepted by a Vertical line
    /// </remarks>
    /// <param name="primaryRectangle">Primary <see cref="Rectangle"/> instance</param>
    /// <param name="secondaryRectangle">Secondary <see cref="Rectangle"/> instance</param>
    /// <returns>A collection of <see cref="Point"/> as Intersection points.</returns>
    private static IEnumerable<Point> GetIntersectionPoints(Rectangle primaryRectangle, Rectangle secondaryRectangle)
    {
        return from horizontalLine in primaryRectangle.GetHorizontalLines() 
            from verticalLine in secondaryRectangle.GetVerticalLines() 
            where horizontalLine.IntersectWith(verticalLine) 
            select horizontalLine.IntersectionPoint(verticalLine);
    }
}
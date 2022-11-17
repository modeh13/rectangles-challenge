using Rectangles.Challenge.Core.Algorithms.Abstractions;
using Rectangles.Challenge.Core.Models;
using Rectangles.Challenge.Core.Models.Enums;

namespace Rectangles.Challenge.Core.Algorithms;

public class IntersectionAlgorithm : IRectangleAlgorithm<IntersectionResult>
{
    public IntersectionResult Execute(Rectangle rectangleA, Rectangle rectangleB)
    {
        var intersectionPoints = new HashSet<Point>();
        var rectangleAVersusB = GetIntersectionPoints(rectangleA, rectangleB);
        var rectangleBVersusA = GetIntersectionPoints(rectangleB, rectangleA);

        AddPoints(intersectionPoints, rectangleAVersusB);
        AddPoints(intersectionPoints, rectangleBVersusA);

        return intersectionPoints.Any() ? 
            new IntersectionResult(ResultType.Intersection, intersectionPoints.OrderBy(p => p.X).ThenBy(p => p.Y).ToList()) :
            new IntersectionResult(ResultType.NoIntersection, new List<Point>());
    }

    /// <summary>
    /// Adds Intersections points to HasSet collection to prevent duplicates.
    /// </summary>
    /// <param name="hashSet"><see cref="HashSet{T}"/> collection</param>
    /// <param name="points">A collection of intersection <see cref="Point"/></param>
    private static void AddPoints(ISet<Point> hashSet, IEnumerable<Point> points)
    {
        foreach (var point in points)
        {
            hashSet.Add(point);
        }
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
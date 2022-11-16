using Rectangles.Challenge.Console.Models;

namespace Rectangles.Challenge.Console.Algorithms.Abstractions;

public interface IRectangleAlgorithm<out TResult> where TResult : ResultBase
{
    /// <summary>
    /// Evaluates and executes algorithm to get the result depending of Algorithm type.
    /// </summary>
    /// <param name="rectangleA">Primary <see cref="Rectangle"/> instance to be compared</param>
    /// <param name="rectangleB">Secondary <see cref="Rectangle"/> instance</param>
    /// <returns>Algorithm result</returns>
    TResult Execute(Rectangle rectangleA, Rectangle rectangleB);
}

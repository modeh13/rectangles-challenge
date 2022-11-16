using Rectangles.Challenge.Console.Models.Enums;

namespace Rectangles.Challenge.Console.Models;

public record ResultBase(ResultType ResultType);

public record IntersectionResult (ResultType ResultType, IList<Point> IntersectionPoints) : ResultBase(ResultType);

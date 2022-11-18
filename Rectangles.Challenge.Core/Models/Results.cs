using Rectangles.Challenge.Core.Models.Enums;

namespace Rectangles.Challenge.Core.Models;

public record ResultBase(ResultType ResultType)
{
    public override string ToString()
    {
        return ResultType.Name;
    }
}

public record IntersectionResult(ResultType ResultType, IList<Point> IntersectionPoints) : ResultBase(ResultType)
{
    public override string ToString()
    {
        if (!IntersectionPoints.Any())
        {
            return base.ToString();
        }

        var intersectionPoints = IntersectionPoints.Select(point => point.ToString());
        return $"{base.ToString()} [{string.Join(",", intersectionPoints)}]";
    }
}

using Rectangles.Challenge.Console.Algorithms.Abstractions;
using Rectangles.Challenge.Console.Models;
using Rectangles.Challenge.Console.Models.Enums;

namespace Rectangles.Challenge.Console.Algorithms;

public class AdjacencyAlgorithm : IRectangleAlgorithm<ResultBase>
{
    public ResultBase Execute(Rectangle rectangleA, Rectangle rectangleB)
    {
        var rectangleALinesFromBottom = new[] { rectangleA.BottomLine, rectangleA.RightLine, rectangleA.TopLine, rectangleA.LeftLine };
        var rectangleBLinesFromTop = new[] { rectangleB.TopLine, rectangleB.LeftLine, rectangleB.BottomLine, rectangleB.RightLine };

        for (var index = 0; index < rectangleALinesFromBottom.Length; index++)
        {
            var primaryLine = rectangleALinesFromBottom[index];
            var secondaryLine = rectangleBLinesFromTop[index];
            var adjacencyTypeId = primaryLine switch
            {
                HorizontalLine => GetAdjacencyTypeIdHorizontal(primaryLine, secondaryLine),
                _ => GetAdjacencyTypeIdVertical(primaryLine, secondaryLine)
            };
            if (ResultType.NotAdjacent.Value != adjacencyTypeId)
            {
                return new ResultBase(ResultType.FromValue(adjacencyTypeId));
            }
        }
        
        return new ResultBase(ResultType.NotAdjacent);
    }

    private static int GetAdjacencyTypeIdHorizontal(Line primaryLine, Line secondaryLine)
    {
        if (primaryLine.Start.Y != secondaryLine.Start.Y)
        {
            return ResultType.NotAdjacent.Value;
        }
        if (primaryLine.Start.X == secondaryLine.Start.X && primaryLine.End.X == secondaryLine.End.X)
        {
            return ResultType.AdjacentProper.Value;
        }
        if (primaryLine.Start.X <= secondaryLine.Start.X && primaryLine.End.X >= secondaryLine.End.X)
        {
            return ResultType.AdjacentSubLine.Value;
        }
        
        return ResultType.AdjacentPartial.Value;
    }
    
    private static int GetAdjacencyTypeIdVertical(Line primaryLine, Line secondaryLine)
    {
        if (primaryLine.Start.X != secondaryLine.Start.X)
        {
            return ResultType.NotAdjacent.Value;
        }
        if (primaryLine.Start.Y == secondaryLine.Start.Y && primaryLine.End.Y == secondaryLine.End.Y)
        {
            return ResultType.AdjacentProper.Value;
        }
        if (primaryLine.Start.Y <= secondaryLine.Start.Y && primaryLine.End.Y >= secondaryLine.End.Y)
        {
            return ResultType.AdjacentSubLine.Value;
        }
        
        return ResultType.AdjacentPartial.Value;
    }
}
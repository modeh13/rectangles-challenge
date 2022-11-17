using Rectangles.Challenge.Core.Algorithms.Abstractions;
using Rectangles.Challenge.Core.Models;
using Rectangles.Challenge.Core.Models.Enums;

namespace Rectangles.Challenge.Core.Algorithms;

public class AdjacencyAlgorithm : IRectangleAlgorithm<ResultBase>
{
    public ResultBase Execute(Rectangle rectangleA, Rectangle rectangleB)
    {
        var rectangleALinesFromBottom = new Line[] { rectangleA.GetBottomLine(), rectangleA.GetRightLine(), rectangleA.GetTopLine(), rectangleA.GetLeftLine() };
        var rectangleBLinesFromTop = new Line[] { rectangleB.GetTopLine(), rectangleB.GetLeftLine(), rectangleB.GetBottomLine(), rectangleB.GetRightLine() };

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
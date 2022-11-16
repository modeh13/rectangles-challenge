using Rectangles.Challenge.Console.Algorithms.Abstractions;
using Rectangles.Challenge.Console.Models;

Console.WriteLine("Test");

// IRectangleAlgorithm intersectionAlgorithm = new IntersectionAlgorithm();
// IRectangleAlgorithm containmentAlgorithm = new ContainmentAlgorithm();

// var rectangleA = new Rectangle(new Point(0, 0), 5, 5);
// var rectangleB = new Rectangle(new Point(2, 2), 4, 4);
// Console.WriteLine($"Intersection Result : {intersectionAlgorithm.GetResult(rectangleA, rectangleB)}");
//
// var rectangleC = new Rectangle(new Point(0, 0), 5, 5);
// var rectangleD = new Rectangle(new Point(2, 2), 2, 2);
// Console.WriteLine($"Containment Result : {containmentAlgorithm.GetResult(rectangleC, rectangleD)}");
// Console.WriteLine($"Contains : {rectangleA.Contains(rectangleB.BottomLeft)}");


// public class ContainmentAlgorithm : IRectangleAlgorithm
// {
//     public string GetResult(Rectangle rectangleA, Rectangle rectangleB)
//     {
//         var isRectangleContained = rectangleA.Contains(rectangleB.BottomLeft) &&
//                                     rectangleA.Contains(rectangleB.TopLeft) &&
//                                     rectangleA.Contains(rectangleB.TopRight) &&
//                                     rectangleA.Contains(rectangleB.BottomRight);
//
//         return isRectangleContained ? "Containment" : "No Containment";
//     }
// }

public class AlgorithmOrchestrator
{
    private readonly IList<IRectangleAlgorithm<ResultBase>> _rectangleAlgorithms;

    public AlgorithmOrchestrator(IList<IRectangleAlgorithm<ResultBase>> rectangleAlgorithms)
    {
        _rectangleAlgorithms = rectangleAlgorithms;
    }

    public string CheckAlgorithms(Rectangle rectangleA, Rectangle rectangleB)
    {
        var results = _rectangleAlgorithms.Select(rectangleAlgorithm => rectangleAlgorithm.Execute(rectangleA, rectangleB));
        
        return string.Join(" - ", results.Select(result => result.ResultType.Name));
    }
}

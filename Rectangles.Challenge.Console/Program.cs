using Rectangles.Challenge.Console.Algorithms;
using Rectangles.Challenge.Console.Algorithms.Abstractions;
using Rectangles.Challenge.Console.Models;

// api/Rectangle/Compare {A, B, A1, A2, A3}

Console.WriteLine("Rectangle Algorithms");

var algorithmOrchestrator = new AlgorithmOrchestrator(new List<IRectangleAlgorithm<ResultBase>>
{
    new IntersectionAlgorithm(),
    new ContainmentAlgorithm(),
    new AdjacencyAlgorithm()
});

var rectangleA = new Rectangle(new Point(0, 0), new Size(5, 5));
var rectangleB = new Rectangle(new Point(2, 2), new Size(4, 4));
var rectangleC = new Rectangle(new Point(2, 2), new Size(3, 3));
var result = algorithmOrchestrator.ExecuteAlgorithms(rectangleA, rectangleC);

Console.WriteLine(result);
System.Drawing.Rectangle rectA = new System.Drawing.Rectangle(0, 0, 5, 5);
Console.WriteLine(rectA.Contains(new System.Drawing.Rectangle(0, 0, 2, 2)));

// [GR] - Review case where Rectangle is contained and is at one of borders.
// [GR] - Document Start and Line

public class AlgorithmOrchestrator
{
    private readonly IList<IRectangleAlgorithm<ResultBase>> _rectangleAlgorithms;

    public AlgorithmOrchestrator(IList<IRectangleAlgorithm<ResultBase>> rectangleAlgorithms)
    {
        _rectangleAlgorithms = rectangleAlgorithms;
    }

    public string ExecuteAlgorithms(Rectangle rectangleA, Rectangle rectangleB)
    {
        var results = _rectangleAlgorithms.Select(rectangleAlgorithm => rectangleAlgorithm.Execute(rectangleA, rectangleB));
        
        return string.Join(" - ", results.Select(result => result.ResultType.Name));
    }
}

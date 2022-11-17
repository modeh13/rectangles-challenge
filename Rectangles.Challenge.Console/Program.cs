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

var rectangleA = new Rectangle(new Point(-1, 1), new Size(4, 4));
var rectangleB = new Rectangle(new Point(2, 3), new Size(4, 4));
var result = algorithmOrchestrator.ExecuteAlgorithms(rectangleA, rectangleB);

Console.WriteLine(result);

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
        
        return string.Join(" - ", results.Select(result => result.ToString()));
    }
}

using Rectangles.Challenge.Core.Algorithms;
using Rectangles.Challenge.Core.Algorithms.Abstractions;
using Rectangles.Challenge.Core.Models;
using Rectangles.Challenge.Core.Models.Enums;
using Rectangles.Challenge.Core.Services.Abstractions;

namespace Rectangles.Challenge.Core.Services;

internal class AlgorithmsService : IAlgorithmsService
{
    private static IEnumerable<IRectangleAlgorithm<ResultBase>> GetAlgorithms(Algorithm algorithm)
    {
        return algorithm switch
        {
            _ when Algorithm.Intersection.Value == algorithm.Value => new List<IRectangleAlgorithm<ResultBase>>{new IntersectionAlgorithm()},
            _ when Algorithm.Containment.Value == algorithm.Value => new List<IRectangleAlgorithm<ResultBase>>{new ContainmentAlgorithm()},
            _ when Algorithm.Adjacency.Value == algorithm.Value => new List<IRectangleAlgorithm<ResultBase>>{new AdjacencyAlgorithm()},
            _ => new List<IRectangleAlgorithm<ResultBase>>
            {
                new IntersectionAlgorithm(),
                new ContainmentAlgorithm(),
                new AdjacencyAlgorithm()
            }
        };
    }

    public string ExecuteAlgorithm(Rectangle rectangleA, Rectangle rectangleB, Algorithm algorithm)
    {
        var results = GetAlgorithms(algorithm)
            .Select(rectangleAlgorithm => rectangleAlgorithm.Execute(rectangleA, rectangleB));
        
        return string.Join(" - ", results.Select(result => result.ToString()));
    }
}
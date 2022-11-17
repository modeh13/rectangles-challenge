using Rectangles.Challenge.Core.Models;
using Rectangles.Challenge.Core.Models.Enums;

namespace Rectangles.Challenge.Core.Services.Abstractions;

public interface IAlgorithmsService
{
    public string ExecuteAlgorithm(Rectangle rectangleA, Rectangle rectangleB, Algorithm algorithm);
}
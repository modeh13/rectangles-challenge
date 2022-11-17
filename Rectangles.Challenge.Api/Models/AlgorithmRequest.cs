using Rectangles.Challenge.Core.Models;

namespace Rectangles.Challenge.Api.Models;

public class AlgorithmRequest
{
    public Rectangle Primary { get; set; }
    public Rectangle Secondary { get; set; }
    public string Algorithm { get; set; }
}
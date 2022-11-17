using Rectangles.Challenge.Api.Models;
using Rectangles.Challenge.Core.Models.Enums;
using Rectangles.Challenge.Core.Services.Abstractions;

namespace Rectangles.Challenge.Api.Extensions;

internal static class WebApplicationExtensions
{
    public static void ConfigureMinimalApi(this WebApplication app)
    {
        app.ConfigureRectanglesApi();
    }
    
    private static void ConfigureRectanglesApi(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/Rectangles/Algorithms", (IAlgorithmsService algorithmsService, AlgorithmRequest algorithmRequest) =>
            {
                if (!Algorithm.TryFromName(algorithmRequest.Algorithm, true, out var algorithm))
                {
                    return Results.BadRequest($"{nameof(algorithmRequest.Algorithm)} not valid.");
                }

                var result = algorithmsService.ExecuteAlgorithm(algorithmRequest.Primary, algorithmRequest.Secondary, algorithm);

                return Results.Ok(new AlgorithmResponse(result));

            })
            .WithTags("Rectangles")
            .Produces(StatusCodes.Status200OK, typeof(AlgorithmResponse))
            .Produces(StatusCodes.Status400BadRequest);
    }
}
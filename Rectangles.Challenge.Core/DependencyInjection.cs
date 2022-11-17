using Microsoft.Extensions.DependencyInjection;
using Rectangles.Challenge.Core.Services;
using Rectangles.Challenge.Core.Services.Abstractions;

namespace Rectangles.Challenge.Core;

public static class DependencyInjection
{
    public static void AddCoreDependencies(this IServiceCollection servicesCollection)
    {
        servicesCollection.AddScoped<IAlgorithmsService, AlgorithmsService>();
    }
}
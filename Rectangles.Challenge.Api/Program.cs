using Microsoft.OpenApi.Models;
using Rectangles.Challenge.Api.Extensions;
using Rectangles.Challenge.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCoreDependencies();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rectangles Challenge - API", Version = "v1" });
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureMinimalApi();

app.Run();

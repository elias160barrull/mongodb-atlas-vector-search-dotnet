using MongoDB.Driver;
using Movies.Search.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();

builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));
builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// get movies endpoint
app.MapGet("api/movies", async (IMovieService movieService, string? term = null, int limit = 10) =>
{
    var movies = await movieService.GetMoviesAsync(term, limit);

    return Results.Ok(movies);
});

app.Run();
using Microsoft.Extensions.AI;
using MongoDB.Driver;
using Movies.Search.Api.Models;

namespace Movies.Search.Api.Services;

public class MovieEmbeddingsGenerator(
    IMovieService movieService,
    IMongoClient mongoClient,
    IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator,
    ILogger<MovieEmbeddingsGenerator> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var database = mongoClient.GetDatabase("sample_mflix");
        var moviesCollection = database.GetCollection<Movie>("embedded_movies");

        try
        {
            // Fetch movies in batches of 10,000
            var movies = await movieService.GetMoviesAsync(limit: 10000);

            if (!movies.Any())
            {
                // If no movies are returned, we've processed all of them
                return;
            }

            // Group movies by their embeddings to minimize API calls
            var moviesWithPlots = movies
                .Where(m => !string.IsNullOrEmpty(m.Plot))
                .Where(m => m.PlotEmbedding1024 is null or { Length: 0 })
                .ToList();
            var embeddings = new Dictionary<string, float[]>();

            // Generate embeddings for all plots
            foreach (var movie in moviesWithPlots)
            {
                if (!embeddings.ContainsKey(movie.Plot))
                {
                    embeddings[movie.Id] = await GenerateEmbeddings(movie.Plot);
                }
            }

            // Create bulk update operations
            var updates = new List<UpdateOneModel<Movie>>();
            foreach (var movie in moviesWithPlots)
            {
                var filter = Builders<Movie>.Filter.Eq(m => m.Id, movie.Id);
                var update = Builders<Movie>.Update.Set(m => m.PlotEmbedding1024, embeddings[movie.Id]);
                updates.Add(new UpdateOneModel<Movie>(filter, update));
            }

            // Execute bulk update
            if (updates.Count != 0)
            {
                await moviesCollection.BulkWriteAsync(updates, cancellationToken: stoppingToken);
            }
        }
        catch (Exception ex)
        {
            // Log the error and continue
            logger.LogError(ex, "Error processing batch: {Message}", ex.Message);
        }
    }

    private async Task<float[]> GenerateEmbeddings(string term)
    {
        var generatedEmbeddings = await embeddingGenerator.GenerateAsync([term]);

        var embedding = generatedEmbeddings.Single();

        return embedding.Vector.ToArray();
    }
}

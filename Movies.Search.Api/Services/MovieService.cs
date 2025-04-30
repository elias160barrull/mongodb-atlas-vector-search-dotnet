using Microsoft.Extensions.AI;
using MongoDB.Driver;
using Movies.Search.Api.Models;

namespace Movies.Search.Api.Services;

public class MovieService : IMovieService
{
    private readonly IMongoCollection<Movie> _moviesCollection;
    private readonly IEmbeddingGenerator<string, Embedding<float>> _embeddingGenerator;

    public MovieService(IMongoClient mongoClient, IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator)
    {
        var database = mongoClient.GetDatabase("sample_mflix");
        _moviesCollection = database.GetCollection<Movie>("embedded_movies");
        _embeddingGenerator = embeddingGenerator;
    }

    public async Task<List<Movie>> GetMoviesAsync(string? term = null, int limit = 10)
    {
        if (string.IsNullOrWhiteSpace(term))
        {
            return await _moviesCollection
                .Find(Builders<Movie>.Filter.Empty)
                .Limit(limit)
                .ToListAsync();
        }

        var vectorEmbeddings = await GenerateEmbeddings(term);

        var vectorSearchOptions = new VectorSearchOptions<Movie>
        {
            IndexName = "vector_index",
            NumberOfCandidates = 200,
            Filter = Builders<Movie>.Filter.Gte(m => m.Year, 2010)
        };

        return await _moviesCollection
            .Aggregate()
            .VectorSearch(movie => movie.PlotEmbedding1024, vectorEmbeddings, limit, vectorSearchOptions)
            .ToListAsync();
    }

    private async Task<float[]> GenerateEmbeddings(string term)
    {
        var generatedEmbeddings = await _embeddingGenerator.GenerateAsync([term]);

        var embedding = generatedEmbeddings.Single();

        return embedding.Vector.ToArray();
    }
}

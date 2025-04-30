using Movies.Search.Api.Models;

namespace Movies.Search.Api.Services;

public class MovieService : IMovieService
{
    public Task<IEnumerable<Movie>> GetMoviesAsync(
        string? searchTerm, 
        int limit)
    {
        // Simulate a delay for the sake of example
        return Task.FromResult(Enumerable.Range(1, limit).Select(i => new Movie
        {
            Id = i,
            Title = $"{searchTerm} Movie {i}",
            Overview = $"Overview of {searchTerm} Movie {i}",
            ReleaseDate = DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd")
        }));
    }
}
using Movies.Search.Api.Models;

namespace Movies.Search.Api.Services;

public interface IMovieService
{
    Task<List<Movie>> GetMoviesAsync(string? searchTerm = null, int limit = 10);
}

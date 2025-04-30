using Movies.Search.Api.Models;

namespace Movies.Search.Api.Services;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetMoviesAsync(string? searchTerm, int limit);
}

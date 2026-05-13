using EveningMovies.Models;

namespace EveningMovies.Services
{
    public interface IEveningMovieService
    {
        List<Movie> GetAllMovies();
        List<Movie> GetMoviesByGenre(string genre);
        List<Movie> GetMoviesByFriend(string friendName);
        void AddMovie(Movie movie);
    }
}
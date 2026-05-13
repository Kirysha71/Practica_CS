using EveningMovies.Models;

namespace EveningMovies.Services
{
    public interface IEveningMovieService
    {
        Task<List<EveningMovie>> GetAllMoviesAsync();
        Task<List<EveningMovie>> GetMoviesByGenreAsync(string genre);
        Task<List<EveningMovie>> GetMoviesByMoodTagAsync(string moodTag);
        Task<List<EveningMovie>> GetMoviesByFriendAsync(string friendName);
        Task AddMovieAsync(EveningMovie movie);
        Task DeleteMovieAsync(int id);
    }
}
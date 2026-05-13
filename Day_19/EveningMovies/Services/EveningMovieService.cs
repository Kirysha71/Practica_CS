using EveningMovies.Data;
using EveningMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace EveningMovies.Services
{
    public class EveningMovieService : IEveningMovieService
    {
        private readonly ApplicationDbContext _context;

        public EveningMovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EveningMovie>> GetAllMoviesAsync()
        {
            return await _context.EveningMovies.ToListAsync();
        }

        public async Task<List<EveningMovie>> GetMoviesByGenreAsync(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
                return await GetAllMoviesAsync();

            return await _context.EveningMovies
                .Where(m => m.Genre == genre)
                .ToListAsync();
        }

        public async Task<List<EveningMovie>> GetMoviesByMoodTagAsync(string moodTag)
        {
            if (string.IsNullOrWhiteSpace(moodTag))
                return await GetAllMoviesAsync();

            return await _context.EveningMovies
                .Where(m => m.MoodTag == moodTag)
                .ToListAsync();
        }

        public async Task<List<EveningMovie>> GetMoviesByFriendAsync(string friendName)
        {
            if (string.IsNullOrWhiteSpace(friendName))
                return await GetAllMoviesAsync();

            return await _context.EveningMovies
                .Where(m => m.AddedBy == friendName)
                .ToListAsync();
        }

        public async Task AddMovieAsync(EveningMovie movie)
        {
            _context.EveningMovies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _context.EveningMovies.FindAsync(id);
            if (movie != null)
            {
                _context.EveningMovies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
using EveningMovies.Models;

namespace EveningMovies.Services
{
    public class EveningMovieService : IEveningMovieService
    {
        private static List<Movie> _movies = new List<Movie>
        {
            new Movie { Id = 1, Title = "Побег из Шоушенка", Genre = "Драма", RecommendedBy = "Алексей" },
            new Movie { Id = 2, Title = "Криминальное чтиво", Genre = "Криминал", RecommendedBy = "Мария" },
            new Movie { Id = 3, Title = "Начало", Genre = "Фантастика", RecommendedBy = "Дмитрий" },
            new Movie { Id = 4, Title = "Титаник", Genre = "Мелодрама", RecommendedBy = "Елена" },
            new Movie { Id = 5, Title = "Матрица", Genre = "Фантастика", RecommendedBy = "Алексей" },
            new Movie { Id = 6, Title = "Бойцовский клуб", Genre = "Драма", RecommendedBy = "Дмитрий" }
        };

        public List<Movie> GetAllMovies()
        {
            return _movies.ToList();
        }

        public List<Movie> GetMoviesByGenre(string genre)
        {
            if (string.IsNullOrWhiteSpace(genre))
                return _movies.ToList();

            return _movies.Where(m => m.Genre == genre).ToList();
        }

        public List<Movie> GetMoviesByFriend(string friendName)
        {
            if (string.IsNullOrWhiteSpace(friendName))
                return _movies.ToList();

            return _movies.Where(m => m.RecommendedBy == friendName).ToList();
        }

        public void AddMovie(Movie movie)
        {
            movie.Id = _movies.Max(m => m.Id) + 1;
            _movies.Add(movie);
        }
    }
}
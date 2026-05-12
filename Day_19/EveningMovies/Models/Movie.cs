namespace EveningMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string RecommendedBy { get; set; } = string.Empty;
    }
}

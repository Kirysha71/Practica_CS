namespace EveningMovies.Models
{
    public class EveningMovie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string MoodTag { get; set; } = string.Empty;
        public string AddedBy { get; set; } = string.Empty;
    }
}

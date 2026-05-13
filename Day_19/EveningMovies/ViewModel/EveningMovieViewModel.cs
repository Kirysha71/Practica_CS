using System;
using System.ComponentModel.DataAnnotations;

namespace EveningMovies.ViewModel
{
    public class EveningMovieViewModel
    {
        [Required(ErrorMessage = "Название фильма обязательно")]
        [Display(Name = "Название фильма")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Жанр обязателен")]
        [Display(Name = "Жанр")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Время начала обязательно")]
        [DataType(DataType.Time)]
        [Display(Name = "Время начала")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Имя друга обязательно")]
        [Display(Name = "Кто рекомендовал")]
        public string RecommendedBy { get; set; }
    }
}
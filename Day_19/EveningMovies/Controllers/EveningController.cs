using Microsoft.AspNetCore.Mvc;
using EveningMovies.Models;
using EveningMovies.Services;

namespace EveningMovies.Controllers
{
    public class EveningController : Controller
    {
        private readonly IEveningMovieService _movieService;

        public EveningController(IEveningMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var movies = _movieService.GetAllMovies();
            ViewBag.Message = "Список всех фильмов";
            return View(movies);
        }

        public IActionResult ByGenre(string genre)
        {
            var movies = _movieService.GetMoviesByGenre(genre);
            ViewBag.Message = string.IsNullOrEmpty(genre) ? "Все фильмы" : $"Жанр: {genre}";
            return View("Index", movies);
        }

        public IActionResult ByFriend(string name)
        {
            var movies = _movieService.GetMoviesByFriend(name);
            ViewBag.Message = string.IsNullOrEmpty(name) ? "Все фильмы" : $"Рекомендовал: {name}";
            return View("Index", movies);
        }

        [HttpGet]
        public IActionResult Suggest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Suggest(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.AddMovie(movie);
                TempData["Success"] = $"Фильм {movie.Title} добавлен!";
                return RedirectToAction("Index");
            }
            return View(movie);
        }
    }
}
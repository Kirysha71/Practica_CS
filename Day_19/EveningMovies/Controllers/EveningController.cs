using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            ViewBag.Message = "Список всех фильмов";
            return View(movies);
        }

        public async Task<IActionResult> ByGenre(string genre)
        {
            var movies = await _movieService.GetMoviesByGenreAsync(genre);
            ViewBag.Message = string.IsNullOrEmpty(genre) ? "Все фильмы" : $"Жанр: {genre}";
            return View("Index", movies);
        }

        public async Task<IActionResult> ByMoodTag(string moodTag)
        {
            var movies = await _movieService.GetMoviesByMoodTagAsync(moodTag);
            ViewBag.Message = string.IsNullOrEmpty(moodTag) ? "Все фильмы" : $"Настроение: {moodTag}";
            return View("Index", movies);
        }

        public async Task<IActionResult> ByFriend(string name)
        {
            var movies = await _movieService.GetMoviesByFriendAsync(name);
            ViewBag.Message = string.IsNullOrEmpty(name) ? "Все фильмы" : $"Рекомендовал: {name}";
            return View("Index", movies);
        }

        [HttpGet]
        public IActionResult Suggest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Suggest(EveningMovie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddMovieAsync(movie);
                TempData["Success"] = $"Фильм \"{movie.Title}\" добавлен!";
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.DeleteMovieAsync(id);
            TempData["Success"] = "Фильм удален!";
            return RedirectToAction("Index");
        }
    }
}
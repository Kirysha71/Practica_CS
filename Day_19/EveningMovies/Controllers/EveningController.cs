using Microsoft.AspNetCore.Mvc;
using EveningMovies.Models;

namespace EveningMovies.Controllers
{
    public class EveningController : Controller
    {
        private static readonly List<Movie> Movies = new()
        {
            new Movie { Id = 1, Title = "Начало", Genre = "Фантастика", RecommendedBy = "Дмитрий" },
            new Movie { Id = 2, Title = "Интерстеллар", Genre = "Фантастика", RecommendedBy = "Дмитрий" },
            new Movie { Id = 3, Title = "Зеленая миля", Genre = "Драма", RecommendedBy = "Дмитрий" },
            new Movie { Id = 4, Title = "Криминальное чтиво", Genre = "Боевик", RecommendedBy = "Дмитрий" }
        };

        public IActionResult Index()
        {
            return View(Movies);
        }

        public IActionResult ByFriend(string name)
        {
            var moviesByFriend = Movies
                .Where(m => m.RecommendedBy.Equals(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            ViewBag.FriendName = name;
            return View(moviesByFriend);
        }

        public IActionResult Suggest()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Suggest(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.Id = Movies.Max(m => m.Id) + 1;
                Movies.Add(movie);
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using MovieECommerce.Contract;

namespace MovieECommerce.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;

        public MovieController(IMovieRepository movieRepo)
        {
            _movieRepo = movieRepo;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _movieRepo.GetMovies();
            return View(movies);
        }

        [HttpPost]
        public IActionResult Search()
        {
            return View();
        }
    }
}

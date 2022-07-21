using Microsoft.AspNetCore.Mvc;
using MovieECommerce.Contract;

namespace MovieECommerce.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaRepository _cinemaRepo;

        public CinemaController(ICinemaRepository cinemaRepo)
        {
            _cinemaRepo = cinemaRepo;
        }
        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemaRepo.GetCinemas();
            return View(cinemas);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MovieECommerce.Controllers
{
    public class CinemaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

 using Microsoft.AspNetCore.Mvc;
using MovieECommerce.Contract;

namespace MovieECommerce.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerRepository _producerRepo;

        public ProducerController(IProducerRepository producerRepo)
        {
            _producerRepo = producerRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

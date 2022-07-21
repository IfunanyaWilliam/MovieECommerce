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
        public async Task<IActionResult> Index()
        {
            var producers = await _producerRepo.GetProducersAsync();
            return View(producers);
        }


    }
}

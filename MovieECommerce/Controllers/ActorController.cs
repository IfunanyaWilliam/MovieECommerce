using Microsoft.AspNetCore.Mvc;
using MovieECommerce.Contract;

namespace MovieECommerce.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorRepo;

        public ActorController(IActorRepository actorRepo)
        {
            _actorRepo = actorRepo;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _actorRepo.GetActorsAsync();
            return View(data);
        }
    }
}

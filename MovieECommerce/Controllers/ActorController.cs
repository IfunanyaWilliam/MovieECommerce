using Microsoft.AspNetCore.Mvc;
using MovieECommerce.Contract;
using MovieECommerce.Models;
using MovieECommerce.ViewModels;

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

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActorViewModel model)
        {
            var actor = new Actor();
            if (ModelState.IsValid)
            {
                
                var result = await _actorRepo.AddActor(actor);
            }
            return View(model);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieECommerce.Contract;
using MovieECommerce.Models;
using MovieECommerce.ViewModels;

namespace MovieECommerce.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorRepo;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ActorController(IActorRepository actorRepo, 
                               IImageService imageService,
                               IMapper mapper)
        {
            _actorRepo = actorRepo;
            _imageService = imageService;
            _mapper = mapper;
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
            var actor = _mapper.Map<Actor>(model); ;
            if (!ModelState.IsValid)
            {
               return View(model);
            }

            //Add Actor photo to Cloudinary and generate absolute path
            string imgUrl = "";

            if (model.ProfilePictureURL is not null)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    await model.ProfilePictureURL.CopyToAsync(stream);
                }
                var uploadResult = await _imageService.UploadImage(filePath);
                imgUrl = uploadResult;
            }

            actor.ProfilePictureURL = imgUrl;
            var result = await _actorRepo.AddActor(actor);
            if (result)
            {
                TempData["ActorAddedSuccessfully"] = "Actor successfully added.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Actor could not be added";
            return View(model);
        }
    }
}

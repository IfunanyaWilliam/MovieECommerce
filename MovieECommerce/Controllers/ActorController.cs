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
            var data = await _actorRepo.GetAllActorsAsync();
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
            if (!ModelState.IsValid)
            {
               return View(model);
            }

            var actor = _mapper.Map<Actor>(model);

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
            var result = await _actorRepo.AddActorAsync(actor);
            if (result)
            {
                TempData["ActorAddedSuccessfully"] = "Actor successfully added.";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Actor could not be added";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string actorId)
        {
            var actor = await _actorRepo.GetActorAsync(a => a.ActorId == actorId);
            if(actor == null)
            {
                TempData["ActorNotFound"] = "Actor could not be found.";
                return RedirectToAction("Index");
            }

            //Map the Actor to ActorEditViewModel since the Edit view takes ActorEditViewModel
            var editActor = _mapper.Map<ActorEditViewModel>(actor);
            return View(editActor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ActorEditViewModel model)
        {
            var actorToModify = await _actorRepo.GetActorAsync(a => a.ActorId == model.ActorId);
            if (actorToModify == null)
            {
                TempData["Error"] = "Could not update Actor";
                return View(model);
            }

            if(model.NewProfilePictureURL != null && model.NewProfilePictureURL.Length > 0)
            {
                var filePath = Path.GetTempFileName();
                 
                using (var stream = System.IO.File.Create(filePath))
                {
                    await model.NewProfilePictureURL.CopyToAsync(stream);
                }
                var imageUplaodURL = await _imageService.UploadImage(filePath);

                if(imageUplaodURL == null)
                {
                    TempData["Error"] = "Could not update Actor";
                    return View(model);
                }

                //Assign NewProfilePictureURL to profilePictureURL of original actor
                actorToModify.ProfilePictureURL = imageUplaodURL;
            }

            actorToModify.FullName      = model.FullName;
            actorToModify.BioInformation = model.BioInformation;

            var result = await _actorRepo.UpdateActorAsync(actorToModify);
            if (result)
            {
                TempData["Success"] = "Actor Successfully Modified";
                return RedirectToAction("Detail", new { actorId = actorToModify.ActorId });
            }
            return View();
        }


        public async Task<IActionResult> Detail(string actorId)
        {
            var actor = await _actorRepo.GetActorAsync(a => a.ActorId == actorId);
            var actorDetail = _mapper.Map<ActorEditViewModel>(actor);
            return View(actorDetail);
        }
    }
}

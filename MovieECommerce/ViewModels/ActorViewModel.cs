using MovieECommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieECommerce.ViewModels
{
    public class ActorViewModel
    {

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Please upload an image of the Actor")]
        public IFormFile? ProfilePictureURL { get; set; }

        [Required(ErrorMessage = "Please enter the full name of the Actor")]
        [Display(Name = "Full Name")]
        public string? FullNname { get; set; }

        [Required(ErrorMessage = "Please add the biography of the Actor")]
        [Display(Name = "Biography")]
        public string? BioInformation { get; set; }

        //Relationship
        public List<Movie_Actor>? MovieActors { get; set; }
    }
}

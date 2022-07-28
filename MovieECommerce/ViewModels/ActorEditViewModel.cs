using MovieECommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieECommerce.ViewModels
{
    public class ActorEditViewModel
    {
        public string? ActorId { get; set; }

        [Display(Name = "Profile Picture")]
        public string? ProfilePictureURL { get; set; }
        public IFormFile? NewProfilePictureURL { get; set; }

        [Required(ErrorMessage = "Please enter the full name of the Actor")]
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "Full Name cannot be more than 100 characters")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Please add the biography of the Actor")]
        [Display(Name = "Biography")]
        public string? BioInformation { get; set; }

        //Relationship
        public List<Movie_Actor>? MovieActors { get; set; }
    }
}

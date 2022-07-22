using System.ComponentModel.DataAnnotations;

namespace MovieECommerce.Models
{
    public class Actor
    {
        [Key]
        public string ActorId { get; private set; } = Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "$");

        [Display(Name = "Profile Picture")]
        public string? ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        public string? FullNname { get; set; }

        [Display(Name = "Biography")]
        public string? BioInformation { get; set; }

        //Relationship
        public List<Movie_Actor>? MovieActors { get; set; }
    }
}

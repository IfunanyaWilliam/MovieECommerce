using System.ComponentModel.DataAnnotations;

namespace MovieECommerce.Models
{
    public class Actor
    {
        [Key]
        public string ActorId { get; set; } = Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "$");
        public string? ProfilePictureURL { get; set; }
        public string? FullNname { get; set; }
        public string? BioInformation { get; set; }

        //Relationship
        public List<Movie_Actor>? MovieActors { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieECommerce.Models
{
    public class Actor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? ActorId { get; set; } 
        public string? ProfilePictureURL { get; set; }
        public string? FullName { get; set; }
        public string? BioInformation { get; set; }

        //Relationship
        public List<Movie_Actor>? MovieActors { get; set; }
    }
}

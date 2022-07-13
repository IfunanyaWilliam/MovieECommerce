using System.ComponentModel.DataAnnotations;

namespace MovieECommerce.Models
{
    public class Actor
    {
        public Actor()
        {
            ActorId = Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "$");
        }
        public string ActorId { get; private set; } 

        public string ProfilePictureURL { get; set; }
        public string FullNname { get; set; }
        public string BioInformation { get; set; }

        //Relationship
        public List<Movie_Actor> MovieActors { get; set; }
    }
}

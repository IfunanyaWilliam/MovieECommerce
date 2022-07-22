using System.ComponentModel.DataAnnotations;

namespace MovieECommerce.Models
{
    public class Movie_Actor
    {
        public string? MovieId { get; set; }
        public Movie? Movie { get; set; }
        public int ActorId { get; set; }
        public Actor? Actor { get; set; }
    }
}

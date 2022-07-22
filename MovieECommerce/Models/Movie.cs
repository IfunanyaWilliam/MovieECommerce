using MovieECommerce.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieECommerce.Models
{
    public class Movie
    {

        [Key]
        public string MovieId { get; private set; } = Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "$");
        public string? Name { get; set; }
        public string? ImageURL { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory Category { get; set; }

        //Relationship
        public List<Movie_Actor>? MovieActors { get; set; }

        //Cinema
        [ForeignKey("CinemaId")]
        public int CinemaId { get; set; }
        public Cinema? Cinema { get; set; }
        
        //Producer
        public int ProducerId { get; set; }
        public Producer? Producer { get; set; }


    }
}

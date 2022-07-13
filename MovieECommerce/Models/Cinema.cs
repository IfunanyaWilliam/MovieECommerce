using System.ComponentModel.DataAnnotations;

namespace MovieECommerce.Models
{
    public class Cinema
    {
        public Cinema()
        {
            CinemaId = Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "$");
        }

        [Key]
        public string CinemaId { get; private set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //relationship
        public List<Movie> Movies { get; set; }
    }
}
 
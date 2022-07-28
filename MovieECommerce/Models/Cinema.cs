using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieECommerce.Models
{
    public class Cinema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CinemaId { get; private set; } = Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "$");

        [Display(Name = "Cinema Logo")]
        public string? Logo { get; set; }

        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }
         
        //relationship
        public List<Movie>? Movies { get; set; }
    }
}
 
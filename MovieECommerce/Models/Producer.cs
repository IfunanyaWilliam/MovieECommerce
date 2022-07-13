using System.ComponentModel.DataAnnotations;

namespace MovieECommerce.Models
{
    public class Producer
    {
        public Producer()
        {
             ProducerId = Guid.NewGuid().ToString().Substring(0, 10).Replace("-", "$");
        }

        [Key]
        public string ProducerId { get; private set; }
        public string ProfilePictureURL { get; set; }
        public string FullNname { get; set; }
        public string BioInformation { get; set; }
        
        
        //Relationships
        public List<Movie> Movies { get; set; }
    }
}

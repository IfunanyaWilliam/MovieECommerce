using MovieECommerce.Models;

namespace MovieECommerce.Contract
{
    public interface ICinemaRepository
    {
        Task<IEnumerable<Cinema>> GetCinemas();
    }
}

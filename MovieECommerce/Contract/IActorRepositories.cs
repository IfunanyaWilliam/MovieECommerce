using MovieECommerce.Models;

namespace MovieECommerce.Contract
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetActorsAsync();
    }
}

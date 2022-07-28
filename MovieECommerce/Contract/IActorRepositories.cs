using MovieECommerce.Models;
using System.Linq.Expressions;

namespace MovieECommerce.Contract
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();

        Task<Actor> GetActorAsync(Expression<Func<Actor, bool>> predicate);

        Task<bool> AddActorAsync(Actor actor);

        Task<bool> UpdateActorAsync(Actor actor);

        Task<bool> DeleteActorAsync(string actorId);
    }
}

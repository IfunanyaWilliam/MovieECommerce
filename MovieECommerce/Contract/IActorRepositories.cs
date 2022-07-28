using MovieECommerce.Models;
using System.Linq.Expressions;

namespace MovieECommerce.Contract
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();

        Task<Actor> GetActorAsync(Expression<Func<Actor, bool>> predicate);

        Task<bool> AddActor(Actor actor);

        Task<bool> UpdateActor(Actor actor);

        Task<bool> DeleteActor(string actorId);
    }
}

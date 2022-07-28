using Microsoft.EntityFrameworkCore;
using MovieECommerce.Contract;
using MovieECommerce.Data;
using MovieECommerce.Models;
using System.Linq.Expressions;

namespace MovieECommerce.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _context;

        public ActorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actor>> GetAllActorsAsync()
        {
            return await _context.Actors.ToListAsync();
        }

        public async Task<Actor> GetActorAsync(Expression<Func<Actor, bool>> predicate)
        {
            return await _context.Actors.AsQueryable().FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> AddActorAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            return await _context.SaveChangesAsync() > 0;
        }
        
        public async Task<bool> UpdateActorAsync(Actor actor)
        {
            var newActor = _context.Actors.Find(actor.ActorId);
            if(newActor is not null)
            {
                _context.Actors.Update(newActor);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> DeleteActorAsync(string actorId)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.ActorId == actorId);
            if(actor is not null)
            {
                _context.Actors.Remove(actor);
                return await _context.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}

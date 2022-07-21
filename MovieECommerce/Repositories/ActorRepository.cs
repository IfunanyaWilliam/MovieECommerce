using Microsoft.EntityFrameworkCore;
using MovieECommerce.Contract;
using MovieECommerce.Data;
using MovieECommerce.Models;

namespace MovieECommerce.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _context;

        public ActorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Actor>> GetActorsAsync()
        {
            return await _context.Actors.ToListAsync();
        }
    }
}

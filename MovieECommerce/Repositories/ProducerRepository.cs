using Microsoft.EntityFrameworkCore;
using MovieECommerce.Contract;
using MovieECommerce.Data;
using MovieECommerce.Models;

namespace MovieECommerce.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly AppDbContext _context;

        public ProducerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producer>> GetProducersAsync()
        {
            return await _context.Producers.Include(m => m.Movies).ToListAsync();
        }
    }
}

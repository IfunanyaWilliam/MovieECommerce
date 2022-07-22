using Microsoft.EntityFrameworkCore;
using MovieECommerce.Contract;
using MovieECommerce.Data;
using MovieECommerce.Models;

namespace MovieECommerce.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly AppDbContext _context;

        public CinemaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cinema>> GetCinemas()
        {
            return await _context.Cinemas.Include(c => c.Movies).ToListAsync();
        }

    }
}

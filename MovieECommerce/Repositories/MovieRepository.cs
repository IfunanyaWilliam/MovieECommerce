using Microsoft.EntityFrameworkCore;
using MovieECommerce.Contract;
using MovieECommerce.Data;
using MovieECommerce.Models;

namespace MovieECommerce.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Movie>> GetMovies()
        {
            return await _context.Movies.Include(mv => mv.MovieActors).Include(c => c.Cinema).OrderBy(n => n.Name).ToListAsync();
        }

    }
}

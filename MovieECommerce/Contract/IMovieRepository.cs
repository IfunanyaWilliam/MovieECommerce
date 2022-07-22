using MovieECommerce.Models;

namespace MovieECommerce.Contract
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMovies();
    }
}

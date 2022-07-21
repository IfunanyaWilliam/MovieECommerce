using MovieECommerce.Models;

namespace MovieECommerce.Contract
{
    public interface IProducerRepository
    {
        Task<IEnumerable<Producer>> GetProducersAsync();
    }
}

using System.Threading.Tasks;
using VnsProjectTrips.Domain.Models;

namespace VnsProjectTrips.Persistence.Interfaces
{
    public interface IMarketPersist
    {
        //EVENTOS
        Task<Market[]> GetAllMarketsByCategoryAsync(string category, bool includeOrders = false);
        Task<Market[]> GetAllMarketsAsync(bool includeOrders = false);
        Task<Market> GetMarketByIdAsync(int marketId, bool includeOrders = false);
    }
}

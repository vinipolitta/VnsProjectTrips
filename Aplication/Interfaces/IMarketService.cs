using System.Threading.Tasks;
using VnsProjectTrips.Domain.Models;

namespace VnsProjectTrips.Aplication.Interfaces
{
    public interface IMarketService
    {
        Task<Market> AddMarkets(Market model);
        Task<Market> UpdateMarket(int marketId, Market model);
        Task<bool> DeleteMarket(int marketId);


        Task<Market[]> GetAllMarketsAsync(bool includeOrders = false);
        Task<Market[]> GetAllMarketsByCategoryAsync(string category, bool includeOrders = false);
        Task<Market> GetMarketByIdAsync(int marketId, bool includeOrders = false);
    }
}

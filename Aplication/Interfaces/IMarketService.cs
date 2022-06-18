using System.Threading.Tasks;
using VnsProjectTrips.Aplication.Dtos;

namespace VnsProjectTrips.Aplication.Interfaces
{
    public interface IMarketService
    {
        Task<MarketDto> AddMarkets(MarketDto model);
        Task<MarketDto> UpdateMarket(int marketId, MarketDto model);
        Task<bool> DeleteMarket(int marketId);


        Task<MarketDto[]> GetAllMarketsAsync(bool includeOrders = false);
        Task<MarketDto[]> GetAllMarketsByCategoryAsync(string category, bool includeOrders = false);
        Task<MarketDto> GetMarketByIdAsync(int marketId, bool includeOrders = false);
    }
}

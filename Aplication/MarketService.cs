using System;
using System.Threading.Tasks;
using VnsProjectTrips.Aplication.Interfaces;
using VnsProjectTrips.Domain.Models;
using VnsProjectTrips.Persistence.Interfaces;

namespace VnsProjectTrips.Aplication
{
    public class MarketService : IMarketService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IMarketPersist _marketPersist;

        public MarketService(IGeralPersist geralPersist, IMarketPersist marketPersist)
        {
            _geralPersist = geralPersist;
            _marketPersist = marketPersist;
        }
        public async Task<Market> AddMarkets(Market model)
        {
            try
            {
                _geralPersist.Add<Market>(model);
                if (await _geralPersist.SavaChangesAsync())
                {
                    return await _marketPersist.GetMarketByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Market> UpdateMarket(int marketId, Market model)
        {
            try
            {
                var market = await _marketPersist.GetMarketByIdAsync(marketId, false);
                if (market == null) return null;

                model.Id = market.Id;

                _geralPersist.Update(model);

                if (await _geralPersist.SavaChangesAsync())
                {
                    return await _marketPersist.GetMarketByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteMarket(int marketId)
        {
            try
            {
                var market = await _marketPersist.GetMarketByIdAsync(marketId, false);
                if (market == null) throw new Exception("Market para delete nao foi encontrado.");

                _geralPersist.Delete<Market>(market);

                return await _geralPersist.SavaChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Market[]> GetAllMarketsAsync(bool includeOrders = false)
        {
            try
            {
                var markets = await _marketPersist.GetAllMarketsAsync(includeOrders);
                if (markets == null) return null;

                return markets;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Market[]> GetAllMarketsByCategoryAsync(string category, bool includeOrders = false)
        {
            try
            {
                var markets = await _marketPersist.GetAllMarketsByCategoryAsync(category,includeOrders);
                if (markets == null) return null;

                return markets;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Market> GetMarketByIdAsync(int marketId, bool includeOrders = false)
        {
            try
            {
                var markets = await _marketPersist.GetMarketByIdAsync(marketId, includeOrders);
                if (markets == null) return null;

                return markets;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

       
    }
}

using AutoMapper;
using System;
using System.Threading.Tasks;
using VnsProjectTrips.Aplication.Dtos;
using VnsProjectTrips.Aplication.Interfaces;
using VnsProjectTrips.Domain.Models;
using VnsProjectTrips.Persistence.Interfaces;

namespace VnsProjectTrips.Aplication
{
    public class MarketService : IMarketService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IMarketPersist _marketPersist;
        private readonly IMapper _mapper;

        public MarketService(IGeralPersist geralPersist, IMarketPersist marketPersist, IMapper mapper)
        {
            _geralPersist = geralPersist;
            _marketPersist = marketPersist;
            _mapper = mapper;
        }
        public async Task<MarketDto> AddMarkets(MarketDto model)
        {
            try
            {
                var market = _mapper.Map<Market>(model);
                _geralPersist.Add<Market>(market);
                if (await _geralPersist.SavaChangesAsync())
                {
                    var eventoEetorno = await _marketPersist.GetMarketByIdAsync(market.Id, false);
                    return _mapper.Map<MarketDto>(eventoEetorno);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<MarketDto> UpdateMarket(int marketId, MarketDto model)
        {
            try
            {
                var market = await _marketPersist.GetMarketByIdAsync(marketId, false);
                if (market == null) return null;

                model.Id = market.Id;

                _mapper.Map(model, market);

                _geralPersist.Update<Market>(market);

                if (await _geralPersist.SavaChangesAsync())
                {
                    var eventoEetorno = await _marketPersist.GetMarketByIdAsync(market.Id, false);
                    return _mapper.Map<MarketDto>(eventoEetorno);
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

        public async Task<MarketDto[]> GetAllMarketsAsync(bool includeOrders = false)
        {
            try
            {
                var markets = await _marketPersist.GetAllMarketsAsync(includeOrders);
                if (markets == null) return null;

                var resultado = _mapper.Map<MarketDto[]>(markets);
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<MarketDto[]> GetAllMarketsByCategoryAsync(string category, bool includeOrders = false)
        {
            try
            {
                var markets = await _marketPersist.GetAllMarketsByCategoryAsync(category, includeOrders);
                if (markets == null) return null;

                var resultado = _mapper.Map<MarketDto[]>(markets);
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<MarketDto> GetMarketByIdAsync(int marketId, bool includeOrders = false)
        {
            try
            {
                var market = await _marketPersist.GetMarketByIdAsync(marketId, includeOrders);
                if (market == null) return null;

                var resultado = _mapper.Map<MarketDto>(market);
                return resultado;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


    }
}

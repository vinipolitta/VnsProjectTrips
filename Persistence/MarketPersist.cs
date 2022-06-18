using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VnsProjectTrips.Data;
using VnsProjectTrips.Domain.Models;
using VnsProjectTrips.Persistence.Interfaces;

namespace VnsProjectTrips.Persistence
{
    public class MarketPersist : IMarketPersist
    {
        private readonly DataContext _dataContext;

        public MarketPersist(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Market[]> GetAllMarketsAsync(bool includeOrders = false)
        {
            IQueryable<Market> query = _dataContext.Markets
                .Include(m => m.Reviews)
                .Include(m => m.MarketItens);


            if (includeOrders)
            {
                query = query.Include(m => m.OrdersMarkets).ThenInclude(om => om.Order);
            }

            query = query
                .AsNoTracking()
                .OrderBy(m => m.Id);
            return await query.ToArrayAsync();

        }

        public async Task<Market[]> GetAllMarketsByCategoryAsync(string category, bool includeOrders = false)
        {
            IQueryable<Market> query = _dataContext.Markets
               .Include(m => m.Reviews)
               .Include(m => m.MarketItens);

            if (includeOrders)
            {
                query = query.Include(m => m.OrdersMarkets).ThenInclude(om => om.Order);
            }

            query = query
                .AsNoTracking()
                .OrderBy(m => m.Id)
                //MUDA A BUSCA
                .Where(m => m.Category
                .ToLower()
                .Contains(category.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Market> GetMarketByIdAsync(int marketId, bool includeOrders = false)
        {
            IQueryable<Market> query = _dataContext.Markets
               .Include(m => m.Reviews)
               .Include(m => m.MarketItens);

            if (includeOrders)
            {
                query = query.Include(m => m.OrdersMarkets).ThenInclude(om => om.Order);
            }

            query = query.AsNoTracking().OrderBy(m => m.Id)
                .Where(m => m.Id == marketId);
            return await query.FirstOrDefaultAsync();
        }
    }
}

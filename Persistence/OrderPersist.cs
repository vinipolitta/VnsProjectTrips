using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VnsProjectTrips.Data;
using VnsProjectTrips.Domain.Models;
using VnsProjectTrips.Persistence.Interfaces;

namespace VnsProjectTrips.Persistence
{
    public class OrderPersist : IOrderPersist
    {
        private readonly DataContext _dataContext;

        public OrderPersist(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Order[]> GetAllOrdersAsync(bool includeMarket = false)
        {
            IQueryable<Order> query = _dataContext.Orders
                .Include(o => o.MarketItens);

            if (includeMarket)
            {
                //PEGA A ORDERS MARKETS E INCLUI MARKET NELA
                query = query
                    .Include(o => o.OrdersMarkets)
                    .ThenInclude(om => om.Market);
            }

            query = query.AsNoTracking().OrderBy(o => o.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Order[]> GetAllOrdersByAddressAsync(string address, bool includeMarket = false)
        {
            IQueryable<Order> query = _dataContext.Orders
               .Include(o => o.MarketItens);

            if (includeMarket)
            {
                //PEGA A ORDERS MARKETS E INCLUI MARKET NELA
                query = query
                    .Include(o => o.OrdersMarkets)
                    .ThenInclude(om => om.Market);
            }

            query = query
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Where(o => o.Address
                .ToLower()
                .Contains(address.ToLower()));

            return await query.ToArrayAsync();
        }


        public async Task<Order> GetOrderByIdAsync(int orderId, bool includeMarket = false)
        {
            IQueryable<Order> query = _dataContext.Orders
              .Include(o => o.MarketItens);

            if (includeMarket)
            {
                //PEGA A ORDERS MARKETS E INCLUI MARKET NELA
                query = query
                    .Include(o => o.OrdersMarkets)
                    .ThenInclude(om => om.Market);
            }

            query = query
                .AsNoTracking()
                .OrderBy(o => o.Id)
                .Where(o => o.Id == orderId);

            return await query.FirstOrDefaultAsync();
        }

    }
}

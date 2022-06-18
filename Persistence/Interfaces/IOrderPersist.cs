using System.Threading.Tasks;
using VnsProjectTrips.Domain.Models;

namespace VnsProjectTrips.Persistence.Interfaces
{
    public interface IOrderPersist
    {
        //PALESTRANTES
        Task<Order[]> GetAllOrdersByAddressAsync(string address, bool includeMarket = false);
        Task<Order[]> GetAllOrdersAsync(bool includeMarket = false);
        Task<Order> GetOrderByIdAsync(int orderId, bool includeMarket = false);

    }
}

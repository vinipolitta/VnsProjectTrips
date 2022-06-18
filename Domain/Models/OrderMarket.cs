namespace VnsProjectTrips.Domain.Models
{
    public class OrderMarket
    {
        //PALESTRANTE EVENTO
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int MarketId { get; set; }
        public Market Market { get; set; }
    }
}

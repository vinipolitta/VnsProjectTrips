using System.Collections.Generic;

namespace VnsProjectTrips.Domain.Models
{
    public class Market
    {
        //EVENTO
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string DeliveryEstimate { get; set; }
        public double Rating { get; set; }
        public string ImagePath { get; set; }
        public string About { get; set; }
        public string Hours { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
        public IEnumerable<MarketItem> MarketItens { get; set; }
        public IEnumerable<OrderMarket> OrdersMarkets { get; set; }

    }
}

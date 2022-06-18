using System.Collections;
using System.Collections.Generic;

namespace VnsProjectTrips.Domain.Models
{
    public class Order
    {
        //PALESTRANTE
        public int Id { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string OptionalAddress { get; set; }
        public string PaymentOption { get; set; }
        public IEnumerable<MarketItem> MarketItens { get; set; }
        public IEnumerable<OrderMarket> OrdersMarkets { get; set; }


    }
}

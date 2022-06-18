using System.Collections.Generic;

namespace VnsProjectTrips.Aplication.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public string OptionalAddress { get; set; }
        public string PaymentOption { get; set; }
        public IEnumerable<MarketItemDto> MarketItens { get; set; }
        public IEnumerable<OrderDto> Orders { get; set; }
    }
}

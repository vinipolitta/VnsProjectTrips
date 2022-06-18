using System.Collections.Generic;

namespace VnsProjectTrips.Aplication.Dtos
{
    public class MarketDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string DeliveryEstimate { get; set; }
        public double Rating { get; set; }
        public string ImagePath { get; set; }
        public string About { get; set; }
        public string Hours { get; set; }
        public IEnumerable<ReviewDto> Reviews { get; set; }
        public IEnumerable<MarketItemDto> MarketItens { get; set; }
        public IEnumerable<OrderDto> OrdersDto{ get; set; }
    }
}

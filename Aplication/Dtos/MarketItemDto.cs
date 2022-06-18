namespace VnsProjectTrips.Aplication.Dtos
{
    public class MarketItemDto
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? MarketId { get; set; }
        public MarketDto Market { get; set; }
        public int? OrderId { get; set; }
        public OrderDto Order { get; set; }

    }
}

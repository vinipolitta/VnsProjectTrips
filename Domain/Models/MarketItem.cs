namespace VnsProjectTrips.Domain.Models
{
    public class MarketItem
    {
        //REDESOCIAL
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? MarketId { get; set; }
        public Market Market { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }

    }
}

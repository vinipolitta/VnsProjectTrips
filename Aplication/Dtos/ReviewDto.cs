namespace VnsProjectTrips.Aplication.Dtos
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public string Name { get; set; }
        public string comments { get; set; }
        public decimal rating { get; set; }
        public int? MarketId { get; set; }
        public MarketDto Market { get; set; }
    }
}

using System;

namespace VnsProjectTrips.Domain.Models
{
    public class Review
    {
        //LOTE
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Name { get; set; }
        public string comments { get; set; }
        public decimal rating { get; set; }
        public int? MarketId { get; set; }
        public Market Market { get; set; }
    }
}

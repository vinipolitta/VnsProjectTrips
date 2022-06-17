using Microsoft.EntityFrameworkCore;
using VnsProjectTrips.Models;

namespace VnsProjectTrips.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Market> Markets { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using VnsProjectTrips.Domain.Models;

namespace VnsProjectTrips.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Market> Markets { get; set; }
        public DbSet<MarketItem> MarketItens { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderMarket> OrdersMarkets { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ONDE UNE 2 TABELAS
            modelBuilder.Entity<OrderMarket>()
                .HasKey(OM => new { OM.MarketId, OM.OrderId });

            //DELETE CASCATE N:N
            modelBuilder.Entity<Market>()
                .HasMany(m => m.MarketItens)
                .WithOne(mi => mi.Market)
                .OnDelete(DeleteBehavior.Cascade);

            //DELETE CASCATE N:N
            modelBuilder.Entity<Order>()
                .HasMany(m => m.MarketItens)
                .WithOne(mi => mi.Order)
                .OnDelete(DeleteBehavior.Cascade);

            //DELETE CASCATE n:1
            modelBuilder.Entity<Review>()
                  .HasOne<Market>(r => r.Market)
                  .WithMany(m => m.Reviews)
                  .HasForeignKey(r => r.MarketId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

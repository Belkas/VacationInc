using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(
          DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext() 
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Minivan> Minivans { get; set; }
        public DbSet<Sedan> Sedans { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<VehicleReturnOrder> VehicleReturnOrders { get; set; }
        public DbSet<VehicleOrder> VehicleOrders { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<ReturnOrder> ReturnOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}

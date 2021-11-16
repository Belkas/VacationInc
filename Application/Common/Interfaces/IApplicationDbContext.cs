using Domain.Entities;
using Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; set; }
        DbSet<VehicleOrder> VehicleOrders { get; set; }
        DbSet<Asset> Assets { get; set; }
        DbSet<Vehicle> Vehicles { get; set; }
        DbSet<Minivan> Minivans { get; set; }
        DbSet<Sedan> Sedans { get; set; }
        DbSet<Truck> Trucks{  get; set; }
        DbSet<ReturnOrder> ReturnOrders { get; set; }
        DbSet<VehicleReturnOrder> VehicleReturnOrders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

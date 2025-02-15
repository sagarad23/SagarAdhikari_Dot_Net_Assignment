using Microsoft.EntityFrameworkCore;
using VehicleServiceBookingApp.Models;

namespace VehicleServiceBookingApp.Data
{
   
    
        public class VehicleServiceContext : DbContext
        {
            public VehicleServiceContext(DbContextOptions<VehicleServiceContext> options)
                : base(options)
            {
            }

            public DbSet<VehicleBooking> VehicleBookings { get; set; }
        }
    
}

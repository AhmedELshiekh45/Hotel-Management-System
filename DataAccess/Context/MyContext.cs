using DataAccessLayer.BaseClass;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class MyContext : IdentityDbContext<User>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }



        public override int SaveChanges()
        {
            HandleTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void HandleTimestamps()
        {
            var entries = ChangeTracker.Entries<Base>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Id = Guid.NewGuid().ToString();
                    entry.Entity.CreatedAt = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.Now;
                }
            }
        }
    }
}

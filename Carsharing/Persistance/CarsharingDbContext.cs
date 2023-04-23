using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class CarsharingDbContext: DbContext, ICarsharingDbContext
    {
        public CarsharingDbContext(DbContextOptions<CarsharingDbContext> opts) : base(opts)
        {
        }

        public DbSet<Car> Cars => Set<Car>();
        public DbSet<User> Users => Set<User>();

        public DbSet<Booking> Bookings => Set<Booking>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

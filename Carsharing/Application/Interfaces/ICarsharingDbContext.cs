using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICarsharingDbContext
    {
        DbSet<Car> Cars { get; }
        DbSet<User> Users { get; }
        DbSet<Booking> Bookings { get; }
        Task<int> SaveChangesAsync(CancellationToken token);
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public interface IDatabaseContext
    {
        DbSet<PressureRecord> PressureRecords { get; set; }

        int SaveChanges();
    }
}

using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public interface IDatabaseContext
    {
        DbSet<VibrationRecord> VibrationRecords { get; set; }

        int SaveChanges();
    }
}

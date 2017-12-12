using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public interface IDatabaseContext
    {
        DbSet<TemperatureRecord> TemperatureRecords { get; set; }

        int SaveChanges();
    }
}

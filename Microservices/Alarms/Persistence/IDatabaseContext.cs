using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public interface IDatabaseContext
    {
        DbSet<AlarmsRecord> AlarmsRecords { get; set; }

        int SaveChanges();
    }
}

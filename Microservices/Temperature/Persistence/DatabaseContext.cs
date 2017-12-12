using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<TemperatureRecord> TemperatureRecords { get; set; }
    }
}

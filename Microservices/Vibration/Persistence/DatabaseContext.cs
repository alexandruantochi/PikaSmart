using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contraints;

namespace Persistence
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new IdConfig());
            modelBuilder.ApplyConfiguration(new UserIdConfig());
            modelBuilder.ApplyConfiguration(new TimeConfig());
            modelBuilder.ApplyConfiguration(new ValueConfig());

        }
        
        public DbSet<VibrationRecord> VibrationRecords { get; set; }
    }
}

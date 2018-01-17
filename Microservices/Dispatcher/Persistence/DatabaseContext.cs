using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Maps;

namespace Persistence
{
    public sealed class DatabaseContext : DbContext,IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserRecordMap());
        }

        public DbSet<UserRecord> UserRecords { get; set; }

    }
}

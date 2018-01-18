using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Maps;

namespace Persistence
{
    public class NotificationContext: DbContext, INotificationContext
    {
        public NotificationContext(DbContextOptions<NotificationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new NotificationTemperatureMap());
        }
        
        public DbSet<NotificationRecord> NotificationRecords { get; set; }
    }
}

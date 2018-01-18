using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public interface INotificationContext
    {
        DbSet<NotificationRecord> NotificationRecords { get; set; }

        int SaveChanges();
    }
}

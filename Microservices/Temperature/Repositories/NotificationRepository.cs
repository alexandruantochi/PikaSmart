using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence;

namespace Repositories
{
    public class NotificationRepository: INotificationRepository
    {
        private readonly INotificationContext _context;

        public NotificationRepository(INotificationContext context)
        {
            _context = context;
        }

        public List<NotificationRecord> GetNotificationAll()
        {
            return _context.NotificationRecords.ToList();
        }

        public NotificationRecord GetNotificationByUserId(Guid userId)
        {
            return _context.NotificationRecords.FirstOrDefault(x => x.UserId == userId);
        }

        public EntityEntry<NotificationRecord> AddNotification(NotificationRecord record)
        {
            var result = _context.NotificationRecords.Add(record);
            _context.SaveChanges();
            return result;
        }

    }
}

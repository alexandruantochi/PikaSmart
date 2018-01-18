using System;
using System.Collections.Generic;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repositories
{
    public interface INotificationRepository
    {

        List<NotificationRecord> GetNotificationAll();

        NotificationRecord GetNotificationByUserId(Guid userId);

        EntityEntry<NotificationRecord> AddNotification(NotificationRecord record);

    }
}

using System;
using System.Linq;
using Domain.Entities;

namespace Persistence.Seeders
{
    public static class DbNotificationInitializer
    {
        public static void Seed(NotificationContext context)
        {
            context.Database.EnsureCreated();

            if (context.NotificationRecords.Any())
            {
                return;
            }

            var records = new[]
            {
                new NotificationRecord
                {
                    UserId = new Guid("C06855B4-C8EA-482F-8C0C-889AA568FEFB"),
                    Text = "Iti arde de joaca",
                    Date = new DateTime(2017, 11, 27, 13, 50, 10)
                },
                new NotificationRecord
                {
                    UserId = new Guid("C06855B4-C8EA-482F-8C0C-889AA568FEFB"),
                    Text = "Ai uitat sa'ti iei pastilele",
                    Date = new DateTime(2017, 11, 27, 14, 10, 51)
                },
                new NotificationRecord
                {
                    UserId = new Guid("C06855B4-C8EA-482F-8C0C-889AA568FEFB"),
                    Text = "Ai uitat sa mananci",
                    Date = new DateTime(2017, 11, 27, 15, 20, 12)
                },
                new NotificationRecord
                {
                    UserId = new Guid("C06855B4-C8EA-482F-8C0C-889AA568FEFB"),
                    Text = "Ai ramas fara bani",
                    Date = new DateTime(2017, 11, 27, 16, 23, 9)
                },
                new NotificationRecord
                {
                    UserId = new Guid("C06855B4-C8EA-482F-8C0C-889AA568FEFB"),
                    Text = "Au venit parintii",
                    Date = new DateTime(2017, 11, 27, 17, 43, 13)
                },
                new NotificationRecord
                {
                    UserId = new Guid("C06855B4-C8EA-482F-8C0C-889AA568FEFB"),
                    Text = "A picat bitcoin",
                    Date = new DateTime(2017, 11, 27, 18, 13, 56)
                },
                new NotificationRecord
                {
                    UserId = new Guid("C06855B4-C8EA-482F-8C0C-889AA568FEFB"),
                    Text = "null pointer",
                    Date = new DateTime(2017, 11, 27, 19, 56, 34)
                }
            };

            foreach (NotificationRecord r in records)
            {
                context.NotificationRecords.Add(r);
            }

            context.SaveChanges();
        }
    }
}

using System;
using System.Linq;
using Domain.Entities;

namespace Persistence.Seeders
{
    public static class DbInitializer
    {
        public static void Seed(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            if (context.AlarmsRecords.Any())
            {
                return;
            }

            var records = new[]
            {
                new AlarmsRecord
                {
                    UserId = new Guid("C06855B4-C8EA-482F-8C0C-889AA568FEFB"),
                    Value = 60,
                    Time = new DateTime(2017, 11, 27, 13, 50, 10)
                },
                new AlarmsRecord
                {
                    UserId = new Guid("9E7F4F1E-2EFA-4D65-AD4F-F7242321A2D5"),
                    Value = 62,
                    Time = new DateTime(2017, 11, 27, 14, 10, 51)
                },
                new AlarmsRecord
                {
                    UserId = new Guid("D6C2CC3A-EBB2-4F4E-AC30-1B69C88ADC53"),
                    Value = 63,
                    Time = new DateTime(2017, 11, 27, 15, 20, 12)
                },
                new AlarmsRecord
                {
                    UserId = new Guid("D3985355-4859-4A28-AF1B-0F40788BF2EB"),
                    Value = 75,
                    Time = new DateTime(2017, 11, 27, 16, 23, 9)
                },
                new AlarmsRecord
                {
                    UserId = new Guid("043DBA7F-353E-49B6-A926-ED1BECCCDE75"),
                    Value = 64,
                    Time = new DateTime(2017, 11, 27, 17, 43, 13)
                },
                new AlarmsRecord
                {
                    UserId = new Guid("99842D55-16BD-421E-8ABB-C333659C9DEB"),
                    Value = 51,
                    Time = new DateTime(2017, 11, 27, 18, 13, 56)
                },
                new AlarmsRecord
                {
                    UserId = new Guid("ACBEDF57-B1AA-477E-BA40-77CE7C0DE882"),
                    Value = 61,
                    Time = new DateTime(2017, 11, 27, 19, 56, 34)
                }
            };

            foreach (AlarmsRecord r in records)
            {
                context.AlarmsRecords.Add(r);
            }

            context.SaveChanges();
        }
    }
}

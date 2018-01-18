using System;

namespace Domain.Entities
{
    public class AlarmsRecord
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}

using System;

namespace Domain.Entities
{
    public class PressureRecord
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}

using System;

namespace Business.Dtos.Atomic
{
    public class AddPressureRecordDto
    {
        public Guid UserId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}

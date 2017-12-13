using System;

namespace Business.Dtos.Atomic
{
    public class GetPressureRecordWithUserDto
    {
        public Guid UserId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}

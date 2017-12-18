using System;

namespace Business.Dtos.Atomic
{
    public class GetPressureRecordDto
    {
        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}

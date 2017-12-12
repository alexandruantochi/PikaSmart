using System;

namespace Business.Dtos
{
    public class GetTemperatureRecordWithUserDto
    {
        public Guid UserId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}

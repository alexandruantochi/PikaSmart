using System;

namespace Business.Dtos
{
    public class GetTemperatureRecordDto
    {
        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}

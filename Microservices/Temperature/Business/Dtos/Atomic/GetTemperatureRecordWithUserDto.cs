using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Dtos
{
    public class GetTemperatureRecordWithUserDto
    {
        public Guid UserId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}

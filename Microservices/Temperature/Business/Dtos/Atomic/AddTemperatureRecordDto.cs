﻿using System;

namespace Business.Dtos
{
    public class AddTemperatureRecordDto
    {
        public Guid UserId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}

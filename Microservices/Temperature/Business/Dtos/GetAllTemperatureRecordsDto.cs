using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Dtos
{
    public class GetAllTemperatureRecordsDto
    {
        public List<GetTemperatureRecordDto> TemperatureRecords;

        public GetAllTemperatureRecordsDto(List<GetTemperatureRecordDto> temperatureRecords)
        {
            TemperatureRecords = temperatureRecords;
        }
    }
}

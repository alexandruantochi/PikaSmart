using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Dtos
{
    public class GetAllTemperatureRecordsDto
    {
        public List<GetTemperatureRecordWithUserDto> TemperatureRecords;

        public GetAllTemperatureRecordsDto(List<GetTemperatureRecordWithUserDto> temperatureRecords)
        {
            TemperatureRecords = temperatureRecords;
        }
    }
}

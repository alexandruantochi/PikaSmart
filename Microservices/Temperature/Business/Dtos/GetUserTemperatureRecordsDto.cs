using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Dtos
{
    public class GetUserTemperatureRecordsDto
    {
        public List<GetTemperatureRecordDto> TemperatureRecords;

        public GetUserTemperatureRecordsDto(List<GetTemperatureRecordDto> temperatureRecords)
        {
            TemperatureRecords = temperatureRecords;
        }
    }
}

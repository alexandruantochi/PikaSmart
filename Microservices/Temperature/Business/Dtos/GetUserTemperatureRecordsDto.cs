using System.Collections.Generic;

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

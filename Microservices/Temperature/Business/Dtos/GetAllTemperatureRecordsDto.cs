using System.Collections.Generic;

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

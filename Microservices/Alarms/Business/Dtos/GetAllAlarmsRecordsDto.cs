using System.Collections.Generic;

namespace Business.Dtos
{
    public class GetAllAlarmsRecordsDto
    {
        public List<GetAlarmsRecordWithUserDto> AlarmsRecords;

        public GetAllAlarmsRecordsDto(List<GetAlarmsRecordWithUserDto> alarmsRecords)
        {
            AlarmsRecords = alarmsRecords;
        }
    }
}

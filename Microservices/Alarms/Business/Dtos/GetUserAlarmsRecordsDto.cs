using System.Collections.Generic;

namespace Business.Dtos
{
    public class GetUserAlarmsRecordsDto
    {
        public List<GetAlarmsRecordDto> AlarmsRecords;

        public GetUserAlarmsRecordsDto(List<GetAlarmsRecordDto> alarmsRecords)
        {
            AlarmsRecords = alarmsRecords;
        }
    }
}

using System.Collections.Generic;

namespace Business.Dtos
{
    public class GetUserPressureRecordsDto
    {
        public List<GetPressureRecordDto> PressureRecords;

        public GetUserPressureRecordsDto(List<GetPressureRecordDto> pressureRecords)
        {
            PressureRecords = pressureRecords;
        }
    }
}

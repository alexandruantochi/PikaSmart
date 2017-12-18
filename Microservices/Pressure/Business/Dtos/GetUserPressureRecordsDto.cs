using System.Collections.Generic;
using Business.Dtos.Atomic;

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

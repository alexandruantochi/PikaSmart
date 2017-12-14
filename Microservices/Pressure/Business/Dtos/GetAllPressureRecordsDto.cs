using System.Collections.Generic;
using Business.Dtos.Atomic;

namespace Business.Dtos
{
    public class GetAllPressureRecordsDto
    {
        public List<GetPressureRecordWithUserDto> PressureRecords;

        public GetAllPressureRecordsDto(List<GetPressureRecordWithUserDto> pressureRecords)
        {
            PressureRecords = pressureRecords;
        }
    }
}

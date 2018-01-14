using System.Collections.Generic;

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

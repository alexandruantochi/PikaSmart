using System.Collections.Generic;

namespace Business.Dtos
{
    public class GetAllVibrationRecordsDto
    {
        public List<GetVibrationRecordWithUserDto> VibrationRecords;

        public GetAllVibrationRecordsDto(List<GetVibrationRecordWithUserDto> vibrationRecords)
        {
            VibrationRecords = vibrationRecords;
        }
    }
}

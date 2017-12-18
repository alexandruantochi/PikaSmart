using System.Collections.Generic;

namespace Business.Dtos
{
    public class GetUserVibrationRecordsDto
    {
        public List<GetVibrationRecordDto> VibrationRecords;

        public GetUserVibrationRecordsDto(List<GetVibrationRecordDto> vibrationRecords)
        {
            VibrationRecords = vibrationRecords;
        }
    }
}

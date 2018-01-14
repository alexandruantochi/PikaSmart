using System.Collections.Generic;
using Business.Services.Queries.AtomicResults;

namespace Business.Services.Queries.GetAllVibrationRecords
{
    public class GetAllVibrationRecordsQueryResult
    {
        public List<GetVibrationRecordWithUserQueryResult> VibrationRecords;

        public GetAllVibrationRecordsQueryResult(List<GetVibrationRecordWithUserQueryResult> vibrationRecords)
        {
            VibrationRecords = vibrationRecords;
        }
    }
}

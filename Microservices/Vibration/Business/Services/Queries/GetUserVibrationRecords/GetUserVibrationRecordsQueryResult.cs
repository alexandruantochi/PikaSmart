using System.Collections.Generic;
using Business.Services.Queries.AtomicResults;

namespace Business.Services.Queries.GetUserVibrationRecords
{
    public class GetUserVibrationRecordsQueryResult
    {
        public List<GetVibrationRecordQueryResult> VibrationRecords;

        public GetUserVibrationRecordsQueryResult(List<GetVibrationRecordQueryResult> vibrationRecords)
        {
            VibrationRecords = vibrationRecords;
        }
    }
}
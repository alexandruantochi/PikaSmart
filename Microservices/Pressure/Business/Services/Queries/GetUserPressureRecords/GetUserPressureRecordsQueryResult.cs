using System.Collections.Generic;
using Business.Services.Queries.AtomicResults;

namespace Business.Services.Queries.GetUserPressureRecords
{
    public class GetUserPressureRecordsQueryResult
    {
        public List<GetPressureRecordQueryResult> PressureRecords;

        public GetUserPressureRecordsQueryResult(List<GetPressureRecordQueryResult> pressureRecords)
        {
            PressureRecords = pressureRecords;
        }
    }
}
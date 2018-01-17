using System.Collections.Generic;
using Business.Services.Queries.AtomicResults;

namespace Business.Services.Queries.GetAllPressureRecords
{
    public class GetAllPressureRecordsQueryResult
    {
        public List<GetPressureRecordWithUserQueryResult> PressureRecords;

        public GetAllPressureRecordsQueryResult(List<GetPressureRecordWithUserQueryResult> pressureRecords)
        {
            PressureRecords = pressureRecords;
        }
    }
}

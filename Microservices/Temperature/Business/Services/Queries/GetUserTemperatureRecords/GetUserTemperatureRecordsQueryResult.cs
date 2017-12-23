using System.Collections.Generic;
using Business.Services.Queries.AtomicResults;

namespace Business.Services.Queries.GetUserTemperatureRecords
{
    public class GetUserTemperatureRecordsQueryResult
    {
        public List<GetTemperatureRecordQueryResult> TemperatureRecords;

        public GetUserTemperatureRecordsQueryResult(List<GetTemperatureRecordQueryResult> temperatureRecords)
        {
            TemperatureRecords = temperatureRecords;
        }
    }
}
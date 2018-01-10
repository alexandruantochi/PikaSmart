using System.Collections.Generic;
using Business.Services.Queries.AtomicResults;

namespace Business.Services.Queries.GetAllTemperatureRecords
{
    public class GetAllTemperatureRecordsQueryResult
    {
        public List<GetTemperatureRecordWithUserQueryResult> TemperatureRecords;

        public GetAllTemperatureRecordsQueryResult(List<GetTemperatureRecordWithUserQueryResult> temperatureRecords)
        {
            TemperatureRecords = temperatureRecords;
        }
    }
}

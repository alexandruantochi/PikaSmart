using System;

namespace Business.Services.Queries.AtomicResults
{
    public class GetTemperatureRecordWithUserQueryResult
    {
        public Guid UserId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}

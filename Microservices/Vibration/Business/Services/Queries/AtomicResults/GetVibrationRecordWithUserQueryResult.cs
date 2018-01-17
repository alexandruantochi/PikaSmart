using System;

namespace Business.Services.Queries.AtomicResults
{
    public class GetVibrationRecordWithUserQueryResult
    {
        public Guid UserId { get; set; }

        public double Value { get; set; }

        public DateTime Time { get; set; }
    }
}

using System;
using MediatR;

namespace Business.Services.Queries.GetUserTemperatureRecords
{
    public class GetUserTemperatureRecordsQuery : IRequest<GetUserTemperatureRecordsQueryResult>
    {
        public Guid UserId { get; set; }

        public GetUserTemperatureRecordsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}

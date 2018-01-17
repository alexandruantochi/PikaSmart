using System;
using MediatR;

namespace Business.Services.Queries.GetUserPressureRecords
{
    public class GetUserPressureRecordsQuery : IRequest<GetUserPressureRecordsQueryResult>
    {
        public Guid UserId { get; set; }

        public GetUserPressureRecordsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}

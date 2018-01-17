using System;
using MediatR;

namespace Business.Services.Queries.GetUserVibrationRecords
{
    public class GetUserVibrationRecordsQuery : IRequest<GetUserVibrationRecordsQueryResult>
    {
        public Guid UserId { get; set; }

        public GetUserVibrationRecordsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}

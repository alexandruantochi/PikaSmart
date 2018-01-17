using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Queries.AtomicResults;
using Business.Services.Queries.GetUserVibrationRecords;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Business.Services.Handlers
{
    public class GetUserVibrationRecordsHandler : IRequestHandler<GetUserVibrationRecordsQuery, GetUserVibrationRecordsQueryResult>
    {
        private readonly IVibrationRepository _repo;
        private readonly IMapper _mapper;

        public GetUserVibrationRecordsHandler(IVibrationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GetUserVibrationRecordsQueryResult> Handle(GetUserVibrationRecordsQuery request, CancellationToken cancellationToken)
        {
            var findings = await _repo.GetByUserIdAsync(request.UserId);

            var results = _mapper.Map<List<VibrationRecord>, List<GetVibrationRecordQueryResult>>(findings);

            return new GetUserVibrationRecordsQueryResult(results);
        }
    }
}

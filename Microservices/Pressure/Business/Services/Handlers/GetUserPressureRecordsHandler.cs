using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Queries.AtomicResults;
using Business.Services.Queries.GetUserPressureRecords;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Business.Services.Handlers
{
    public class GetUserPressureRecordsHandler : IRequestHandler<GetUserPressureRecordsQuery, GetUserPressureRecordsQueryResult>
    {
        private readonly IPressureRepository _repo;
        private readonly IMapper _mapper;

        public GetUserPressureRecordsHandler(IPressureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GetUserPressureRecordsQueryResult> Handle(GetUserPressureRecordsQuery request, CancellationToken cancellationToken)
        {
            var findings = await _repo.GetByUserIdAsync(request.UserId);

            var results = _mapper.Map<List<PressureRecord>, List<GetPressureRecordQueryResult>>(findings);

            return new GetUserPressureRecordsQueryResult(results);
        }
    }
}

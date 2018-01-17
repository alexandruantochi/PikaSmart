using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Queries.AtomicResults;
using Business.Services.Queries.GetAllPressureRecords;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Business.Services.Handlers
{
    public class GetAllPressureRecordsHandler : IRequestHandler<GetAllPressureRecordsQuery, GetAllPressureRecordsQueryResult>
    {
        private readonly IPressureRepository _repo;
        private readonly IMapper _mapper;

        public GetAllPressureRecordsHandler(IPressureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GetAllPressureRecordsQueryResult> Handle(GetAllPressureRecordsQuery request, CancellationToken cancellationToken)
        {
            var findings = await _repo.GetAllAsync();

            var results = _mapper.Map<List<PressureRecord>, List<GetPressureRecordWithUserQueryResult>>(findings);

            return new GetAllPressureRecordsQueryResult(results);
        }
    }
}


using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Queries.AtomicResults;
using Business.Services.Queries.GetAllVibrationRecords;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Business.Services.Handlers
{
    public class GetAllVibrationRecordsHandler : IRequestHandler<GetAllVibrationRecordsQuery, GetAllVibrationRecordsQueryResult>
    {
        private readonly IVibrationRepository _repo;
        private readonly IMapper _mapper;

        public GetAllVibrationRecordsHandler(IVibrationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GetAllVibrationRecordsQueryResult> Handle(GetAllVibrationRecordsQuery request, CancellationToken cancellationToken)
        {
            var findings = await _repo.GetAllAsync();

            var results = _mapper.Map<List<VibrationRecord>, List<GetVibrationRecordWithUserQueryResult>>(findings);

            return new GetAllVibrationRecordsQueryResult(results);
        }
    }
}


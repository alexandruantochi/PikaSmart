using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Queries.AtomicResults;
using Business.Services.Queries.GetUserTemperatureRecords;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Business.Services.Handlers
{
    public class GetUserTemperatureRecordsHandler : IRequestHandler<GetUserTemperatureRecordsQuery, GetUserTemperatureRecordsQueryResult>
    {
        private readonly ITemperatureRepository _repo;
        private readonly IMapper _mapper;

        public GetUserTemperatureRecordsHandler(ITemperatureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GetUserTemperatureRecordsQueryResult> Handle(GetUserTemperatureRecordsQuery request, CancellationToken cancellationToken)
        {
            var findings = await _repo.GetByUserIdAsync(request.UserId);

            var results = _mapper.Map<List<TemperatureRecord>, List<GetTemperatureRecordQueryResult>>(findings);

            return new GetUserTemperatureRecordsQueryResult(results);
        }
    }
}

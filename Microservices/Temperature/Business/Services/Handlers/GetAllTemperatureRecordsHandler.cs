using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Queries.AtomicResults;
using Business.Services.Queries.GetAllTemperatureRecords;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Business.Services.Handlers
{
    public class GetAllTemperatureRecordsHandler : IRequestHandler<GetAllTemperatureRecordsQuery, GetAllTemperatureRecordsQueryResult>
    {
        private readonly ITemperatureRepository _repo;
        private readonly IMapper _mapper;

        public GetAllTemperatureRecordsHandler(ITemperatureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<GetAllTemperatureRecordsQueryResult> Handle(GetAllTemperatureRecordsQuery request, CancellationToken cancellationToken)
        {
            var findings = await _repo.GetAllAsync();

            var results = _mapper.Map<List<TemperatureRecord>, List<GetTemperatureRecordWithUserQueryResult>>(findings);

            return new GetAllTemperatureRecordsQueryResult(results);
        }
    }
}


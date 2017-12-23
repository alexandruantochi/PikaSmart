using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Commands.AddTemperatureRecord;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Business.Services.Handlers
{
    public class AddTemperatureRecordHandler : IRequestHandler<AddTemperatureRecordCommand, AddTemperatureRecordCommandResult>
    {
        private readonly ITemperatureRepository _repo;
        private readonly IMapper _mapper;

        public AddTemperatureRecordHandler(ITemperatureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AddTemperatureRecordCommandResult> Handle(AddTemperatureRecordCommand request, CancellationToken cancellationToken)
        {
            var toStore = _mapper.Map<TemperatureRecord>(request);

            await _repo.AddAsync(toStore);
            await _repo.SaveChangesAsync();

            return new AddTemperatureRecordCommandResult(toStore.Id);
        }
    }
}

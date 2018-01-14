using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Commands.AddPressureRecord;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Business.Services.Handlers
{
    public class AddPressureRecordHandler : IRequestHandler<AddPressureRecordCommand, AddPressureRecordCommandResult>
    {
        private readonly IPressureRepository _repo;
        private readonly IMapper _mapper;

        public AddPressureRecordHandler(IPressureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AddPressureRecordCommandResult> Handle(AddPressureRecordCommand request, CancellationToken cancellationToken)
        {
            var toStore = _mapper.Map<PressureRecord>(request);

            await _repo.AddAsync(toStore);
            await _repo.SaveChangesAsync();

            return new AddPressureRecordCommandResult(toStore.Id);
        }
    }
}

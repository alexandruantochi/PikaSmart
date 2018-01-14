using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Commands.AddVibrationRecord;
using Domain.Entities;
using MediatR;
using Repositories;

namespace Business.Services.Handlers
{
    public class AddVibrationRecordHandler : IRequestHandler<AddVibrationRecordCommand, AddVibrationRecordCommandResult>
    {
        private readonly IVibrationRepository _repo;
        private readonly IMapper _mapper;

        public AddVibrationRecordHandler(IVibrationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AddVibrationRecordCommandResult> Handle(AddVibrationRecordCommand request, CancellationToken cancellationToken)
        {
            var toStore = _mapper.Map<VibrationRecord>(request);

            await _repo.AddAsync(toStore);
            await _repo.SaveChangesAsync();

            return new AddVibrationRecordCommandResult(toStore.Id);
        }
    }
}

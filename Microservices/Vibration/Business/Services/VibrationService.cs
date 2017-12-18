using AutoMapper;
using Repositories;

namespace Business.Services
{
    public partial class VibrationService : IVibrationService
    {
        private readonly IVibrationRepository _repo;
        private readonly IMapper _mapper;

        public VibrationService(IVibrationRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}

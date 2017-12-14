using AutoMapper;
using Repositories;

namespace Business.Services
{
    public partial class TemperatureService : ITemperatureService
    {
        private readonly ITemperatureRepository _repo;
        private readonly IMapper _mapper;

        public TemperatureService(ITemperatureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}

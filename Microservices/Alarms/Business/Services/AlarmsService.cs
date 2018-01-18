using AutoMapper;
using Repositories;

namespace Business.Services
{
    public partial class AlarmsService : IAlarmsService
    {
        private readonly IAlarmsRepository _repo;
        private readonly IMapper _mapper;

        public AlarmsService(IAlarmsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}

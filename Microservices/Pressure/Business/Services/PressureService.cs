using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Repositories;

namespace Business.Services
{
    public partial class PressureService : IPressureService
    {
        private readonly IPressureRepository _repo;
        private readonly IMapper _mapper;

        public PressureService(IPressureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
    }
}

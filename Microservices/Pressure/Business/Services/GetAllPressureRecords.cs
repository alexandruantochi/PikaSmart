using System.Collections.Generic;
using Business.Dtos;
using Business.Dtos.Atomic;
using Domain.Entities;

namespace Business.Services
{
    public partial class PressureService
    {
        public GetAllPressureRecordsDto GetAllPressureRecords()
        {
            var findings = _repo.GetAll();

            var results = _mapper.Map<List<PressureRecord>, List<GetPressureRecordWithUserDto>>(findings);

            return new GetAllPressureRecordsDto(results);
        }
    }
}

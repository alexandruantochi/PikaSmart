using System;
using System.Collections.Generic;
using Business.Dtos;
using Business.Dtos.Atomic;
using Domain.Entities;

namespace Business.Services
{
    public partial class PressureService
    {
        public GetUserPressureRecordsDto GetUserPressureRecords(Guid id)
        {
            var findings = _repo.GetByUserId(id);

            var results = _mapper.Map<List<PressureRecord>, List<GetPressureRecordDto>>(findings);

            return new GetUserPressureRecordsDto(results);
        }
    }
}

using System;
using System.Collections.Generic;
using Business.Dtos;
using Domain.Entities;

namespace Business.Services
{
    public partial class VibrationService
    {
        public GetUserVibrationRecordsDto GetUserVibrationRecords(Guid id)
        {
            var findings = _repo.GetByUserId(id);

            var results = _mapper.Map<List<VibrationRecord>, List<GetVibrationRecordDto>>(findings);

            return new GetUserVibrationRecordsDto(results);

        }
    }
}

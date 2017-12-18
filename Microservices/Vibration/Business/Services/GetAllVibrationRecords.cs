using System.Collections.Generic;
using Business.Dtos;
using Domain.Entities;

namespace Business.Services
{
    public partial class VibrationService
    {
        public GetAllVibrationRecordsDto GetAllVibrationRecords()
        {
            var findings = _repo.GetAll();

            var results = _mapper.Map<List<VibrationRecord>, List<GetVibrationRecordWithUserDto>>(findings);

            return new GetAllVibrationRecordsDto(results);
        }
    }
}

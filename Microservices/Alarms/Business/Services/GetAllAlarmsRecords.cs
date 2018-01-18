using System.Collections.Generic;
using Business.Dtos;
using Domain.Entities;

namespace Business.Services
{
    public partial class AlarmsService
    {
        public GetAllAlarmsRecordsDto GetAllAlarmsRecords()
        {
            var findings = _repo.GetAll();

            var results = _mapper.Map<List<AlarmsRecord>, List<GetAlarmsRecordWithUserDto>>(findings);

            return new GetAllAlarmsRecordsDto(results);
        }
    }
}

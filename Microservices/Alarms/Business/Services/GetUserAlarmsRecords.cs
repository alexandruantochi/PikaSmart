using System;
using System.Collections.Generic;
using Business.Dtos;
using Domain.Entities;

namespace Business.Services
{
    public partial class AlarmsService
    {
        public GetUserAlarmsRecordsDto GetUserAlarmsRecords(Guid id)
        {
            var findings = _repo.GetByUserId(id);

            var results = _mapper.Map<List<AlarmsRecord>, List<GetAlarmsRecordDto>>(findings);

            return new GetUserAlarmsRecordsDto(results);

        }
    }
}

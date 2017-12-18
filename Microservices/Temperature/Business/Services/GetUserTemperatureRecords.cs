using System;
using System.Collections.Generic;
using Business.Dtos;
using Domain.Entities;

namespace Business.Services
{
    public partial class TemperatureService
    {
        public GetUserTemperatureRecordsDto GetUserTemperatureRecords(Guid id)
        {
            var findings = _repo.GetByUserId(id);

            var results = _mapper.Map<List<TemperatureRecord>, List<GetTemperatureRecordDto>>(findings);

            return new GetUserTemperatureRecordsDto(results);

        }
    }
}

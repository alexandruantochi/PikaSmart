using System;
using System.Collections.Generic;
using System.Text;
using Business.Dtos;
using Domain.Entities;

namespace Business.Services
{
    public partial class TemperatureService
    {
        public GetAllTemperatureRecordsDto GetAllTemperatureRecords()
        {
            var findings = _repo.GetAll();

            var results = _mapper.Map<List<TemperatureRecord>, List<GetTemperatureRecordWithUserDto>>(findings);

            return new GetAllTemperatureRecordsDto(results);
        }
    }
}

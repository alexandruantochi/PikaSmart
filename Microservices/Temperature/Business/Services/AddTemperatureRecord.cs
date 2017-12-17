using System;
using Business.Dtos;
using Domain.Entities;

namespace Business.Services
{
    public partial class TemperatureService
    {
        public Guid AddTemperatureRecord(AddTemperatureRecordDto record)
        {
            var toStore = _mapper.Map<TemperatureRecord>(record);

            _repo.Add(toStore);
            _repo.SaveChanges();

            return toStore.Id;
        }
    }
}

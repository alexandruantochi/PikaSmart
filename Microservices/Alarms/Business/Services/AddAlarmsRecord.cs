using System;
using Business.Dtos;
using Domain.Entities;

namespace Business.Services
{
    public partial class AlarmsService
    {
        public Guid AddAlarmsRecord(AddAlarmsRecordDto record)
        {
            var toStore = _mapper.Map<AlarmsRecord>(record);

            _repo.Add(toStore);
            _repo.SaveChanges();

            return toStore.Id;
        }
    }
}

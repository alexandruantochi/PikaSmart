using System;
using Business.Dtos.Atomic;
using Domain.Entities;

namespace Business.Services
{
    public partial class PressureService
    {
        public Guid AddPressureRecord(AddPressureRecordDto record)
        {
            var toStore = _mapper.Map<PressureRecord>(record);

            _repo.Add(toStore);
            _repo.SaveChanges();

            return toStore.Id;
        }
    }
}

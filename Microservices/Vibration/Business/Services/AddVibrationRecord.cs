using System;
using Business.Dtos;
using Domain.Entities;

namespace Business.Services
{
    public partial class VibrationService
    {
        public Guid AddVibrationRecord(AddVibrationRecordDto record)
        {
            var toStore = _mapper.Map<VibrationRecord>(record);

            _repo.Add(toStore);
            _repo.SaveChanges();

            return toStore.Id;
        }
    }
}

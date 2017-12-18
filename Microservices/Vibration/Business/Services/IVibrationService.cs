using System;
using Business.Dtos;

namespace Business.Services
{
    public interface IVibrationService
    {
        GetAllVibrationRecordsDto GetAllVibrationRecords();

        GetUserVibrationRecordsDto GetUserVibrationRecords(Guid id);

        Guid AddVibrationRecord(AddVibrationRecordDto record);
    }
}

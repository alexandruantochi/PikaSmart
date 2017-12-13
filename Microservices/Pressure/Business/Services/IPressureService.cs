using System;
using Business.Dtos;
using Business.Dtos.Atomic;

namespace Business.Services
{
    public interface IPressureService
    {
        GetAllPressureRecordsDto GetAllPressureRecords();

        GetUserPressureRecordsDto GetUserPressureRecords(Guid id);

        Guid AddPressureRecord(AddPressureRecordDto record);
    }
}

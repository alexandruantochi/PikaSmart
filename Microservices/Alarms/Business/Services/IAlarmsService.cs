using System;
using Business.Dtos;

namespace Business.Services
{
    public interface IAlarmsService
    {
        GetAllAlarmsRecordsDto GetAllAlarmsRecords();

        GetUserAlarmsRecordsDto GetUserAlarmsRecords(Guid id);

        Guid AddAlarmsRecord(AddAlarmsRecordDto record);
    }
}

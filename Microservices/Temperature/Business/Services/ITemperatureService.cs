using System;
using System.Collections.Generic;
using System.Text;
using Business.Dtos;

namespace Business.Services
{
    public interface ITemperatureService
    {
        GetAllTemperatureRecordsDto GetAllTemperatureRecords();

        GetUserTemperatureRecordsDto GetUserTemperatureRecords(Guid id);

        Guid AddTemperatureRecord(AddTemperatureRecordDto record);
    }
}

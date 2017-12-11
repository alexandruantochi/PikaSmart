using System;
using System.Collections.Generic;
using System.Text;
using Business.Dtos;

namespace Business.Services
{
    public interface ITemperatureServices
    {
        GetAllTemperatureRecordsDto GetAllTemperatureRecords();

        GetTemperatureRecordDto GetTemperatureRecord(Guid id);

        void AddTemperatureRecord(AddTemperatureRecordDto record);
    }
}

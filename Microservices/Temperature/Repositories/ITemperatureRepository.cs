using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Repositories
{
    public interface ITemperatureRepository
    {
        List<TemperatureRecord> GetAll();
            
        TemperatureRecord GetByUserId(Guid id);

        void Add(TemperatureRecord record);

        void SaveChanges();
    }
}

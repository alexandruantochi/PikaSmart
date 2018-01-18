using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Repositories
{
    public interface IAlarmsRepository
    {
        List<AlarmsRecord> GetAll();
            
        List<AlarmsRecord> GetByUserId(Guid userId);

        void Add(AlarmsRecord record);

        void SaveChanges();
    }
}

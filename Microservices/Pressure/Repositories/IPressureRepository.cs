using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Repositories
{
    public interface IPressureRepository
    {
        List<PressureRecord> GetAll();
            
        List<PressureRecord> GetByUserId(Guid userId);

        void Add(PressureRecord record);

        void SaveChanges();
    }
}

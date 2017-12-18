using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Repositories
{
    public interface IVibrationRepository
    {
        List<VibrationRecord> GetAll();
            
        List<VibrationRecord> GetByUserId(Guid userId);

        void Add(VibrationRecord record);

        void SaveChanges();
    }
}

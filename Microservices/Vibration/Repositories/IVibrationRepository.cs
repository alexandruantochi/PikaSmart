using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repositories
{
    public interface IVibrationRepository
    {
        Task<List<VibrationRecord>> GetAllAsync();
            
        Task<List<VibrationRecord>> GetByUserIdAsync(Guid userId);

        Task<EntityEntry<VibrationRecord>> AddAsync(VibrationRecord record);

        Task<int> SaveChangesAsync();
    }
}

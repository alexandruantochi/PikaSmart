using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repositories
{
    public interface IPressureRepository
    {
        Task<List<PressureRecord>> GetAllAsync();
            
        Task<List<PressureRecord>> GetByUserIdAsync(Guid userId);

        Task<EntityEntry<PressureRecord>> AddAsync(PressureRecord record);

        Task<int> SaveChangesAsync();
    }
}

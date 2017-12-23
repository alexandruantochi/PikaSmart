using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Repositories
{
    public interface ITemperatureRepository
    {
        Task<List<TemperatureRecord>> GetAllAsync();
            
        Task<List<TemperatureRecord>> GetByUserIdAsync(Guid userId);

        Task<EntityEntry<TemperatureRecord>> AddAsync(TemperatureRecord record);

        Task<int> SaveChangesAsync();
    }
}

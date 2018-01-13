using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence;

namespace Repositories
{
    public class TemperatureRepository : ITemperatureRepository
    {
        private readonly IDatabaseContext _context;

        public TemperatureRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public Task<List<TemperatureRecord>> GetAllAsync()
        {
            return _context.TemperatureRecords.AsNoTracking().ToListAsync();
        }

        public Task<List<TemperatureRecord>> GetByUserIdAsync(Guid userId)
        {
            return _context.TemperatureRecords.Where(x => x.UserId == userId).AsNoTracking().ToListAsync();
        }

        public Task<EntityEntry<TemperatureRecord>> AddAsync(TemperatureRecord record)
        {
            return _context.TemperatureRecords.AddAsync(record);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}

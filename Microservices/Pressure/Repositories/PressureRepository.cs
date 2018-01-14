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
    public class PressureRepository : IPressureRepository
    {
        private readonly IDatabaseContext _context;

        public PressureRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public Task<List<PressureRecord>> GetAllAsync()
        {
            return _context.PressureRecords.AsNoTracking().ToListAsync();
        }

        public Task<List<PressureRecord>> GetByUserIdAsync(Guid userId)
        {
            return _context.PressureRecords.Where(x => x.UserId == userId).AsNoTracking().ToListAsync();
        }

        public Task<EntityEntry<PressureRecord>> AddAsync(PressureRecord record)
        {
            return _context.PressureRecords.AddAsync(record);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}

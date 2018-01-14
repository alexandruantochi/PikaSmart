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
    public class VibrationRepository : IVibrationRepository
    {
        private readonly IDatabaseContext _context;

        public VibrationRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public Task<List<VibrationRecord>> GetAllAsync()
        {
            return _context.VibrationRecords.AsNoTracking().ToListAsync();
        }

        public Task<List<VibrationRecord>> GetByUserIdAsync(Guid userId)
        {
            return _context.VibrationRecords.Where(x => x.UserId == userId).AsNoTracking().ToListAsync();
        }

        public Task<EntityEntry<VibrationRecord>> AddAsync(VibrationRecord record)
        {
            return _context.VibrationRecords.AddAsync(record);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}

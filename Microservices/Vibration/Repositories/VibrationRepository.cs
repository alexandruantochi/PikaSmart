using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public List<VibrationRecord> GetAll()
        {
            return _context.VibrationRecords.AsNoTracking().ToList();
        }

        public List<VibrationRecord> GetByUserId(Guid userId)
        {
            return _context.VibrationRecords.Where(x => x.UserId == userId).AsNoTracking().ToList();
        }

        public void Add(VibrationRecord record)
        {
            _context.VibrationRecords.Add(record);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

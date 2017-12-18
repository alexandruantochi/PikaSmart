using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public List<PressureRecord> GetAll()
        {
            return _context.PressureRecords.AsNoTracking().ToList();
        }

        public List<PressureRecord> GetByUserId(Guid userId)
        {
            return _context.PressureRecords.Where(x => x.UserId == userId).AsNoTracking().ToList();
        }

        public void Add(PressureRecord record)
        {
            _context.PressureRecords.Add(record);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

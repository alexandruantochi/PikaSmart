using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Repositories
{
    public class AlarmsRepository : IAlarmsRepository
    {
        private readonly IDatabaseContext _context;

        public AlarmsRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public List<AlarmsRecord> GetAll()
        {
            return _context.AlarmsRecords.AsNoTracking().ToList();
        }

        public List<AlarmsRecord> GetByUserId(Guid userId)
        {
            return _context.AlarmsRecords.Where(x => x.UserId == userId).AsNoTracking().ToList();
        }

        public void Add(AlarmsRecord record)
        {
            _context.AlarmsRecords.Add(record);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

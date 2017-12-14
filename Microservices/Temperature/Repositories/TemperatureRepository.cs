using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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

        public List<TemperatureRecord> GetAll()
        {
            return _context.TemperatureRecords.AsNoTracking().ToList();
        }

        public List<TemperatureRecord> GetByUserId(Guid userId)
        {
            return _context.TemperatureRecords.Where(x => x.UserId == userId).AsNoTracking().ToList();
        }

        public void Add(TemperatureRecord record)
        {
            _context.TemperatureRecords.Add(record);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using Domain.Entities;
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
            return _context.TemperatureRecords.ToList();
        }

        public List<TemperatureRecord> GetByUserId(Guid userId)
        {
            return _context.TemperatureRecords.Where(x => x.UserId == userId).ToList();
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

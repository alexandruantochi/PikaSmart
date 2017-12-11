using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Business.Dtos;
using Domain.Entities;
using Repositories;

namespace Business.Services
{
    public class TemperatureServices : ITemperatureServices
    {
        private readonly ITemperatureRepository _repo;
        private readonly IMapper _mapper;

        public TemperatureServices(ITemperatureRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public GetAllTemperatureRecordsDto GetAllTemperatureRecords()
        {
            var findings = _repo.GetAll();

            var results = _mapper.Map<List<TemperatureRecord>, List<GetTemperatureRecordDto>>(findings);

            return new GetAllTemperatureRecordsDto(results);
        }

        public GetTemperatureRecordDto GetTemperatureRecord(Guid id)
        {
            var finding = _repo.GetByUserId(id);

            var result = _mapper.Map<GetTemperatureRecordDto>(finding);

            return result;
        }

        public void AddTemperatureRecord(AddTemperatureRecordDto record)
        {
            var toStore = _mapper.Map<TemperatureRecord>(record);

            _repo.Add(toStore);

            _repo.SaveChanges();
        }
    }
}

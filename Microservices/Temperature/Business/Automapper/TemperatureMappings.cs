using AutoMapper;
using Business.Services.Commands.AddTemperatureRecord;
using Business.Services.Queries.AtomicResults;
using Domain.Entities;

namespace Business.Automapper
{
    public class TemperatureMappings : Profile
    {
        public TemperatureMappings()
        {
            CreateMap<TemperatureRecord, GetTemperatureRecordQueryResult>();
            CreateMap<TemperatureRecord, GetTemperatureRecordWithUserQueryResult>();
            CreateMap<AddTemperatureRecordCommand, TemperatureRecord>();
        }
    }
}

using AutoMapper;
using Business.Dtos;
using Domain.Entities;

namespace Business.Automapper
{
    public class TemperatureMappings : Profile
    {
        public TemperatureMappings()
        {
            CreateMap<TemperatureRecord, GetTemperatureRecordDto>();
            CreateMap<TemperatureRecord, GetTemperatureRecordWithUserDto>();
            CreateMap<AddTemperatureRecordDto, TemperatureRecord>();
        }
    }
}

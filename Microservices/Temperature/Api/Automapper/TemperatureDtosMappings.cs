using AutoMapper;
using Business.Dtos;
using Business.Services.Commands.AddTemperatureRecord;
using Business.Services.Queries.GetAllTemperatureRecords;
using Business.Services.Queries.GetUserTemperatureRecords;

namespace Api.Automapper
{
    public class TemperatureDtosMappings : Profile
    {
        public TemperatureDtosMappings()
        {
            CreateMap<GetAllTemperatureRecordsQueryResult, GetAllTemperatureRecordsDto>();
            CreateMap<GetUserTemperatureRecordsQueryResult, GetUserTemperatureRecordsDto>();
            CreateMap<AddTemperatureRecordDto, AddTemperatureRecordCommand>();
        }
    }
}

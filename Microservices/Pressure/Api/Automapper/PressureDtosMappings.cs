using AutoMapper;
using Business.Dtos;
using Business.Services.Commands.AddPressureRecord;
using Business.Services.Queries.GetAllPressureRecords;
using Business.Services.Queries.GetUserPressureRecords;

namespace Api.Automapper
{
    public class PressureDtosMappings : Profile
    {
        public PressureDtosMappings()
        {
            CreateMap<GetAllPressureRecordsQueryResult, GetAllPressureRecordsDto>();
            CreateMap<GetUserPressureRecordsQueryResult, GetUserPressureRecordsDto>();
            CreateMap<AddPressureRecordDto, AddPressureRecordCommand>();
        }
    }
}

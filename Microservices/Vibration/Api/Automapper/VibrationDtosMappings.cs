using AutoMapper;
using Business.Dtos;
using Business.Services.Commands.AddVibrationRecord;
using Business.Services.Queries.GetAllVibrationRecords;
using Business.Services.Queries.GetUserVibrationRecords;

namespace Api.Automapper
{
    public class VibrationDtosMappings : Profile
    {
        public VibrationDtosMappings()
        {
            CreateMap<GetAllVibrationRecordsQueryResult, GetAllVibrationRecordsDto>();
            CreateMap<GetUserVibrationRecordsQueryResult, GetUserVibrationRecordsDto>();
            CreateMap<AddVibrationRecordDto, AddVibrationRecordCommand>();
        }
    }
}

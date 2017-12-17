using AutoMapper;
using Business.Dtos;
using Domain.Entities;

namespace Business.Automapper
{
    public class VibrationMappings : Profile
    {
        public VibrationMappings()
        {
            CreateMap<VibrationRecord, GetVibrationRecordDto>();
            CreateMap<VibrationRecord, GetVibrationRecordWithUserDto>();
            CreateMap<AddVibrationRecordDto, VibrationRecord>();
        }
    }
}

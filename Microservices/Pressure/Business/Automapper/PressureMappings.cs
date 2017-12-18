using AutoMapper;
using Business.Dtos.Atomic;
using Domain.Entities;

namespace Business.Automapper
{
    public class PressureMappings : Profile
    {
        public PressureMappings()
        {
            CreateMap<PressureRecord, GetPressureRecordDto>();
            CreateMap<PressureRecord, GetPressureRecordWithUserDto>();
            CreateMap<AddPressureRecordDto, PressureRecord>();
        }
    }
}

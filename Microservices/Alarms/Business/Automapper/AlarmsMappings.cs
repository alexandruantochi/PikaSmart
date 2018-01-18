using AutoMapper;
using Business.Dtos;
using Domain.Entities;

namespace Business.Automapper
{
    public class AlarmsMappings : Profile
    {
        public AlarmsMappings()
        {
            CreateMap<AlarmsRecord, GetAlarmsRecordDto>();
            CreateMap<AlarmsRecord, GetAlarmsRecordWithUserDto>();
            CreateMap<AddAlarmsRecordDto, AlarmsRecord>();
        }
    }
}

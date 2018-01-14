using AutoMapper;
using Business.Services.Commands.AddPressureRecord;
using Business.Services.Queries.AtomicResults;
using Domain.Entities;

namespace Business.Automapper
{
    public class PressureMappings : Profile
    {
        public PressureMappings()
        {
            CreateMap<PressureRecord, GetPressureRecordQueryResult>();
            CreateMap<PressureRecord, GetPressureRecordWithUserQueryResult>();
            CreateMap<AddPressureRecordCommand, PressureRecord>();
        }
    }
}

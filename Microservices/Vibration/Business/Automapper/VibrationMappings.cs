using AutoMapper;
using Business.Services.Commands.AddVibrationRecord;
using Business.Services.Queries.AtomicResults;
using Domain.Entities;

namespace Business.Automapper
{
    public class VibrationMappings : Profile
    {
        public VibrationMappings()
        {
            CreateMap<VibrationRecord, GetVibrationRecordQueryResult>();
            CreateMap<VibrationRecord, GetVibrationRecordWithUserQueryResult>();
            CreateMap<AddVibrationRecordCommand, VibrationRecord>();
        }
    }
}

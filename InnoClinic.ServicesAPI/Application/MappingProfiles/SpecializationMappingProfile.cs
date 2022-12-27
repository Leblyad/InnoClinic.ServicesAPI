using AutoMapper;
using InnoClinic.ServicesAPI.Core.Entities.DataTransferObject;
using InnoClinic.ServicesAPI.Core.Entities.Models;

namespace InnoClinic.ServicesAPI.Services.MappingProfiles
{
    public class SpecializationMappingProfile : Profile
    {
        public SpecializationMappingProfile()
        {
            CreateMap<Specialization, SpecializationDto>();

            CreateMap<SpecializationForCreationDto, Specialization>();

            CreateMap<SpecializationForUpdateDto, Specialization>().ReverseMap();
        }
    }
}

using AutoMapper;
using InnoClinic.ServicesAPI.Core.Entities.DataTransferObject;
using InnoClinic.ServicesAPI.Core.Entities.Models;

namespace InnoClinic.ServicesAPI.Services.MappingProfiles
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Service, ServiceDto>();

            CreateMap<ServiceForCreationDto, Service>();

            CreateMap<ServiceForUpdateDto, Service>().ReverseMap();
        }
    }
}

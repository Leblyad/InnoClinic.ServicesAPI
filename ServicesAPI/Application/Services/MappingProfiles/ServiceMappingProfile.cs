using AutoMapper;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Services.MappingProfiles
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

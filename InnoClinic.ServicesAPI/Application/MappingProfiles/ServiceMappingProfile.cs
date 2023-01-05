using AutoMapper;
using InnoClinic.ServicesAPI.Application.Entities.DataTransferObject;
using InnoClinic.ServicesAPI.Core.Entities.Models;
using InnoClinic.SharedModels;

namespace InnoClinic.ServicesAPI.Services.MappingProfiles
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Service, ServiceDto>();

            CreateMap<ServiceForCreationDto, Service>();

            CreateMap<ServiceForUpdateDto, Service>().ReverseMap();

            CreateMap<Service, ServiceUpdatedMessage>();
        }
    }
}

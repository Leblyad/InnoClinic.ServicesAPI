using AutoMapper;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Service, ServiceDto>();

            CreateMap<ServiceForCreationDto, Service>();

            CreateMap<ServiceForUpdateDto, Service>().ReverseMap();

            CreateMap<ServiceCategory, ServiceCategoryDto>();

            CreateMap<ServiceCategoryForCreationDto, ServiceCategory>();

            CreateMap<ServiceCategoryForUpdateDto, ServiceCategory>().ReverseMap();
        }
    }
}

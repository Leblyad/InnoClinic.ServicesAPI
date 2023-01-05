using AutoMapper;
using InnoClinic.ServicesAPI.Application.Entities.DataTransferObject;
using InnoClinic.ServicesAPI.Core.Entities.Models;

namespace InnoClinic.ServicesAPI.Services.MappingProfiles
{
    public class ServiceCategoryMappingProfile : Profile
    {
        public ServiceCategoryMappingProfile()
        {
            CreateMap<ServiceCategory, ServiceCategoryDto>();

            CreateMap<ServiceCategoryForCreationDto, ServiceCategory>();

            CreateMap<ServiceCategoryForUpdateDto, ServiceCategory>().ReverseMap();
        }
    }
}

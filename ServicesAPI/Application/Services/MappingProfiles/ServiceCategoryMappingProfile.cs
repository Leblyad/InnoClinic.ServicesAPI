using AutoMapper;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.Models;

namespace ServicesAPI.Services.MappingProfiles
{
    public class ServiceCategoryMappingProfile : Profile
    {
        protected ServiceCategoryMappingProfile()
        {
            CreateMap<ServiceCategory, ServiceCategoryDto>();

            CreateMap<ServiceCategoryForCreationDto, ServiceCategory>();

            CreateMap<ServiceCategoryForUpdateDto, ServiceCategory>().ReverseMap();
        }
    }
}

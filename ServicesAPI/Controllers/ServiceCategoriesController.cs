using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Services.Abstractions;

namespace ServicesAPI.Controllers
{
    [Route("api/service_categories")]
    [ApiController]
    public class ServiceCategoriesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ServiceCategoriesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet("{serviceCategoryId:guid}")]
        public async Task<IActionResult> GetServiceCategoryById(Guid serviceCategoryId)
        {
            var serviceCategoryDto = await _serviceManager.CategoryService.GetServiceCategoryAsync(serviceCategoryId);

            return Ok(serviceCategoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceCategories()
        {
            var serviceCategoriesDto = await _serviceManager.CategoryService.GetAllServiceCategoriesAsync();

            return Ok(serviceCategoriesDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceCategory([FromBody] ServiceCategoryForCreationDto serviceCategoryForCreationDto)
        {
            var serviceCategoryDto = await _serviceManager.CategoryService.CreateServiceCategory(serviceCategoryForCreationDto);

            return CreatedAtAction(nameof(GetServiceCategoryById), new { serviceCategoryId = serviceCategoryDto.Id }, serviceCategoryDto);
        }

        [HttpPut("{serviceCategoryId:guid}")]
        public async Task<IActionResult> UpdateServiceCategory(Guid serviceId, [FromBody] ServiceCategoryForUpdateDto serviceCategoryForUpdateDto)
        {
            await _serviceManager.CategoryService.UpdateServiceCategory(serviceId, serviceCategoryForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{serviceCategoryId:guid}")]
        public async Task<IActionResult> DeleteServiceCategory(Guid serviceCategoryId)
        {
            await _serviceManager.CategoryService.DeleteServiceCategory(serviceCategoryId);

            return NoContent();
        }
    }
}

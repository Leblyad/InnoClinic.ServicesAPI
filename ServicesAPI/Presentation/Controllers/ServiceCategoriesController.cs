using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.QueryParameters;
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
        public async Task<IActionResult> GetServiceCategories([FromQuery] ServiceCategoryParameters serviceCategoryParameters)
        {
            var serviceCategoriesDto = await _serviceManager.CategoryService.GetAllServiceCategoriesAsync(serviceCategoryParameters);

            return Ok(serviceCategoriesDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceCategory([FromBody] ServiceCategoryForCreationDto serviceCategoryForCreationDto)
        {
            var serviceCategoryDto = await _serviceManager.CategoryService.CreateServiceCategoryAsync(serviceCategoryForCreationDto);

            return CreatedAtAction(nameof(GetServiceCategoryById), new { serviceCategoryId = serviceCategoryDto.Id }, serviceCategoryDto);
        }

        [HttpPut("{serviceCategoryId:guid}")]
        public async Task<IActionResult> UpdateServiceCategory(Guid serviceCategoryId, [FromBody] ServiceCategoryForUpdateDto serviceCategoryForUpdateDto)
        {
            await _serviceManager.CategoryService.UpdateServiceCategoryAsync(serviceCategoryId, serviceCategoryForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{serviceCategoryId:guid}")]
        public async Task<IActionResult> DeleteServiceCategory(Guid serviceCategoryId)
        {
            await _serviceManager.CategoryService.DeleteServiceCategoryAsync(serviceCategoryId);

            return NoContent();
        }
    }
}

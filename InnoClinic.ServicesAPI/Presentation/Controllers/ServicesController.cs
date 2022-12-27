using InnoClinic.ServicesAPI.Core.Entities.DataTransferObject;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;
using InnoClinic.ServicesAPI.Core.Services.Abstractions;
using InnoClinic.ServicesAPI.Presentation.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoClinic.ServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ServicesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Authorize(Roles = nameof(UserRole.Doctor))]
        [HttpGet]
        public async Task<IActionResult> GetServices([FromQuery] ServiceParameters serviceParameters)
        {
            var servicesDto = await _serviceManager.Service.GetAllServicesAsync(serviceParameters);

            return Ok(servicesDto);
        }

        [HttpGet("{serviceId:guid}")]
        public async Task<IActionResult> GetServiceById(Guid serviceId)
        {
            var serviceDto = await _serviceManager.Service.GetServiceAsync(serviceId);

            return Ok(serviceDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] ServiceForCreationDto serviceForCreationDto)
        {
            var serviceDto = await _serviceManager.Service.CreateServiceAsync(serviceForCreationDto);

            return CreatedAtAction(nameof(GetServiceById), new { serviceId = serviceDto.Id }, serviceDto);
        }

        [HttpPut("{serviceId:guid}")]
        public async Task<IActionResult> UpdateService(Guid serviceId, [FromBody] ServiceForUpdateDto serviceForUpdateDto)
        {
            await _serviceManager.Service.UpdateServiceAsync(serviceId, serviceForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{serviceId:guid}")]
        public async Task<IActionResult> DeleteService(Guid serviceId)
        {
            await _serviceManager.Service.DeleteServiceAsync(serviceId);

            return NoContent();
        }
    }
}

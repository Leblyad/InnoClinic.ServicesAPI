using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Services.Abstractions;

namespace ServicesAPI.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ServicesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var servicesDto = await _serviceManager.Service.GetAllServicesAsync();

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

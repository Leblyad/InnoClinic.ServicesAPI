using InnoClinic.ServicesAPI.Presentation.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InnoClinic.ServicesAPI.Core.Entities.DataTransferObject;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;
using InnoClinic.ServicesAPI.Core.Services.Abstractions;

namespace InnoClinic.ServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public SpecializationController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpecializations([FromQuery] SpecializationParameters specializationParameters)
        {
            var specializationsDto = await _serviceManager.Specialization.GetAllSpecializationsAsync(specializationParameters);

            return Ok(specializationsDto);
        }

        [HttpGet("{specializationId:guid}")]
        public async Task<IActionResult> GetSpecializationById(Guid specializationId)
        {
            var specializationDto = await _serviceManager.Specialization.GetSpecializationAsync(specializationId);

            return Ok(specializationDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialization([FromBody] SpecializationForCreationDto specializationForCreationDto)
        {
            var specializationDto = await _serviceManager.Specialization.CreateSpecializationAsync(specializationForCreationDto);

            return CreatedAtAction(nameof(GetSpecializationById), new { specializationId = specializationDto.Id }, specializationDto);
        }

        [HttpPut("{specializationId:guid}")]
        public async Task<IActionResult> UpdateSpecialization(Guid specializationId, [FromBody] SpecializationForUpdateDto specializationForUpdateDto)
        {
            await _serviceManager.Specialization.UpdateSpecializationAsync(specializationId, specializationForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{specializationId:guid}")]
        public async Task<IActionResult> DeleteSpecialization(Guid specializationId)
        {
            await _serviceManager.Specialization.DeleteSpecializationAsync(specializationId);

            return NoContent();
        }
    }
}

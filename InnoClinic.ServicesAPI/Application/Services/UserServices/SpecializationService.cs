using AutoMapper;
using InnoClinic.ServicesAPI.Application.Entities.DataTransferObject;
using InnoClinic.ServicesAPI.Core.Contracts;
using InnoClinic.ServicesAPI.Core.Entities.Models;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;
using InnoClinic.ServicesAPI.Core.Exceptions;
using InnoClinic.ServicesAPI.Core.Exceptions.UserClassExceptions;
using InnoClinic.ServicesAPI.Core.Services.Abstractions.UserServices;

namespace InnoClinic.ServicesAPI.Core.Services.UserServices
{
    public class SpecializationService : ISpecializationService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SpecializationService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<SpecializationDto> CreateSpecializationAsync(SpecializationForCreationDto specialization)
        {
            if (specialization == null)
            {
                throw new CustomNullReferenceException(typeof(SpecializationForCreationDto));
            }

            var specializationEntity = _mapper.Map<Specialization>(specialization);
            await _repositoryManager.Specialization.CreateSpecializationAsync(specializationEntity);

            return _mapper.Map<SpecializationDto>(specializationEntity);
        }

        public async Task DeleteSpecializationAsync(Guid specializationId)
        {
            var specialization = await _repositoryManager.Specialization.GetSpecializationAsync(specializationId);

            if (specialization == null)
            {
                throw new SpecializationNotFoundException(specializationId);
            }

            await _repositoryManager.Specialization.DeleteSpecializationAsync(specialization);
        }

        public async Task<IEnumerable<SpecializationDto>> GetAllSpecializationsAsync(SpecializationParameters specializationParameters)
        {
            var specializations = await _repositoryManager.Specialization.GetAllSpecializationsAsync(specializationParameters);

            return _mapper.Map<IEnumerable<SpecializationDto>>(specializations);
        }

        public async Task<SpecializationDto> GetSpecializationAsync(Guid specializationId)
        {
            var specialization = await _repositoryManager.Specialization.GetSpecializationAsync(specializationId);

            if (specialization == null)
            {
                throw new SpecializationNotFoundException(specializationId);
            }

            return _mapper.Map<SpecializationDto>(specialization);
        }

        public async Task UpdateSpecializationAsync(Guid specializationId, SpecializationForUpdateDto specialization)
        {
            if (specialization == null)
            {
                throw new CustomNullReferenceException(typeof(SpecializationForUpdateDto));
            }

            var specializationEntity = await _repositoryManager.Specialization.GetSpecializationAsync(specializationId, trackChanges: true);

            if (specializationEntity == null)
            {
                throw new SpecializationNotFoundException(specializationId);
            }

            _mapper.Map(specialization, specializationEntity);

            await _repositoryManager.SaveAsync();
        }
    }
}

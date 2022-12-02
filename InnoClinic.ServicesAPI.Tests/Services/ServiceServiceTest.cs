using AutoFixture;
using AutoMapper;
using Moq;
using ServicesAPI.Core.Contracts;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Entities.QueryParameters;
using ServicesAPI.Core.Exceptions;
using ServicesAPI.Core.Exceptions.UserClassExceptions;
using ServicesAPI.Core.Services.Abstractions.UserServices;
using ServicesAPI.Core.Services.UserServices;

namespace InnoClinic.ServicesAPI.Tests.Services
{
    public class ServiceServiceTest
    {
        [Fact]
        public async Task GetAllServicesAsync_WithDefaultParameters_ReturnsServiceDtoItems()
        {
            //Arrange
            ServiceService service;
            var parameters = new ServiceParameters();
            var repositoryMock = new Mock<IRepositoryManager>();
            var items = new Fixture().CreateMany<Service>().AsEnumerable();
            repositoryMock.Setup(x => x.Service.GetAllServicesAsync(parameters, false)).ReturnsAsync(items);
            var repository = repositoryMock.Object;
            var mapperMock = new Mock<IMapper>().Object;
            service = new ServiceService(repository, mapperMock);

            //Act
            var actual = await service.GetAllServicesAsync(parameters);

            //Assert
            Assert.IsAssignableFrom<IEnumerable<ServiceDto>>(actual);
        }

        [Fact]
        public async Task CreateServiceAsync_ValidObjectPassed_ReturnsServiceDto()
        {
            //Arrange
            ServiceService service;
            var repositoryMock = new Mock<IRepositoryManager>();
            var mapperMock = new Mock<IMapper>();
            var serviceForcreation = new ServiceForCreationDto();
            var serviceDto = new ServiceDto();
            var serviceEntity = new Service();
            mapperMock.Setup(x => x.Map<Service>(serviceForcreation)).Returns(serviceEntity);
            mapperMock.Setup(x => x.Map<ServiceDto>(serviceEntity)).Returns(serviceDto);
            repositoryMock.Setup(x => x.Service.CreateServiceAsync(serviceEntity));
            var mapper = mapperMock.Object;
            var repository = repositoryMock.Object;
            service = new ServiceService(repository, mapper);

            //Act
            var actual = await service.CreateServiceAsync(serviceForcreation);

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public async Task CreateServiceAsync_InvalidObjectPassed_ReturnsNullReferenceException()
        {
            //Arrange
            ServiceService service;
            var repositoryMock = new Mock<IRepositoryManager>();
            var mapperMock = new Mock<IMapper>();
            ServiceForCreationDto serviceForcreation = null;
            var serviceDto = new ServiceDto();
            var serviceEntity = new Service();
            mapperMock.Setup(x => x.Map<Service>(serviceForcreation)).Returns(serviceEntity);
            mapperMock.Setup(x => x.Map<ServiceDto>(serviceEntity)).Returns(serviceDto);
            repositoryMock.Setup(x => x.Service.CreateServiceAsync(serviceEntity));
            var mapper = mapperMock.Object;
            var repository = repositoryMock.Object;
            service = new ServiceService(repository, mapper);

            //Assert
            await Assert.ThrowsAsync<ServiceNullReferenceException>(async () => await service.CreateServiceAsync(serviceForcreation));
        }

        [Fact]
        public async Task GetServiceAsync_ExistingGuidPassed_ReturnsServiceDto()
        {
            //Arrange
            ServiceService service;
            var repositoryMock = new Mock<IRepositoryManager>();
            var mapperMock = new Mock<IMapper>();
            var serviceId = Guid.NewGuid();
            var serviceDto = new ServiceDto();
            var serviceEntity = new Service();
            mapperMock.Setup(x => x.Map<ServiceDto>(serviceEntity)).Returns(serviceDto);
            repositoryMock.Setup(x => x.Service.GetServiceAsync(serviceId, false)).ReturnsAsync(serviceEntity);
            var mapper = mapperMock.Object;
            var repository = repositoryMock.Object;
            service = new ServiceService(repository, mapper);

            //Act
            var actual = await service.GetServiceAsync(serviceId);

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public async Task GetServiceAsync_NotExistingGuidPassed_ReturnsNotFoundException()
        {
            //Arrange
            ServiceService service;
            var repositoryMock = new Mock<IRepositoryManager>();
            var mapperMock = new Mock<IMapper>();
            Guid serviceId = Guid.Empty;
            var serviceDto = new ServiceDto();
            var serviceEntity = new Service();
            mapperMock.Setup(x => x.Map<ServiceDto>(serviceEntity)).Returns(serviceDto);
            repositoryMock.Setup(x => x.Service.GetServiceAsync(serviceId, false));
            var mapper = mapperMock.Object;
            var repository = repositoryMock.Object;
            service = new ServiceService(repository, mapper);

            //Assert
            await Assert.ThrowsAsync<ServiceNotFoundException>(async () => await service.GetServiceAsync(serviceId));
        }

        [Fact]
        public async Task DeleteServiceAsync_NotExistingGuidPassed_ReturnsNullReferenceException()
        {
            //Arrange
            ServiceService service;
            var repositoryMock = new Mock<IRepositoryManager>();
            var mapperMock = new Mock<IMapper>();
            var serviceId = Guid.Empty;
            var serviceEntity = new Service();
            repositoryMock.Setup(x => x.Service.DeleteServiceAsync(serviceEntity));
            var mapper = mapperMock.Object;
            var repository = repositoryMock.Object;
            service = new ServiceService(repository, mapper);

            //Assert
            await Assert.ThrowsAsync<ServiceNotFoundException>(async () => await service.DeleteServiceAsync(serviceId));
        }

        [Fact]
        public async Task UpdateServiceAsync_NotExistingGuidPassed_ReturnsNotFoundException()
        {
            //Arrange
            ServiceService service;
            var repositoryMock = new Mock<IRepositoryManager>();
            var mapperMock = new Mock<IMapper>();
            var serviceId = Guid.Empty;
            var serviceForUpdate = new ServiceForUpdateDto();
            var serviceEntity = new Service();
            mapperMock.Setup(x => x.Map<Service>(serviceForUpdate)).Returns(serviceEntity);
            repositoryMock.Setup(x => x.Service.GetServiceAsync(serviceId, false));
            var mapper = mapperMock.Object;
            var repository = repositoryMock.Object;
            service = new ServiceService(repository, mapper);

            //Assert
            await Assert.ThrowsAsync<ServiceNotFoundException>(async () => await service.UpdateServiceAsync(serviceId, serviceForUpdate));
        }

        [Fact]
        public async Task UpdateServiceAsync_InvalidObjectForCreationPassed_ReturnsNullReferenceException()
        {
            //Arrange
            ServiceService service;
            var repositoryMock = new Mock<IRepositoryManager>();
            var mapperMock = new Mock<IMapper>();
            var serviceId = Guid.NewGuid();
            ServiceForUpdateDto serviceForUpdate = null;
            var serviceEntity = new Service();
            mapperMock.Setup(x => x.Map<Service>(serviceForUpdate)).Returns(serviceEntity);
            repositoryMock.Setup(x => x.Service.GetServiceAsync(serviceId, false));
            var mapper = mapperMock.Object;
            var repository = repositoryMock.Object;
            service = new ServiceService(repository, mapper);

            //Assert
            await Assert.ThrowsAsync<ServiceNullReferenceException>(async () => await service.UpdateServiceAsync(serviceId, serviceForUpdate));
        }
    }
}
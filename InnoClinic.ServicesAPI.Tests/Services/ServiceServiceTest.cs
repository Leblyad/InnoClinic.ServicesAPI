using AutoFixture;
using AutoMapper;
using MockQueryable.Moq;
using Moq;
using ServicesAPI.Core.Contracts;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Entities.QueryParameters;
using ServicesAPI.Core.Exceptions.UserClassExceptions;
using ServicesAPI.Core.Services.UserServices;

namespace InnoClinic.ServicesAPI.Tests.Services
{
    public class ServiceServiceTest
    {
        private readonly ServiceService service;
        private readonly Mock<IRepositoryManager> repositoryMock;
        private readonly Mock<IMapper> mapperMock;

        public ServiceServiceTest()
        {
            repositoryMock = new Mock<IRepositoryManager>();
            mapperMock = new Mock<IMapper>();
            service = new ServiceService(repositoryMock.Object, mapperMock.Object);
        }

        [Fact]
        public async Task GetAllServicesAsync_WithDefaultParameters_ReturnsItems()
        {
            //Arrange
            var parameters = new ServiceParameters();
            parameters.PageNumber = 2;
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var take = parameters.PageSize;

            var serviceItem = new Service()
            {
                Id = new Guid("d976d96d-94d3-4351-9e36-29389e39154a"),
                Price = 10,
                ServiceName = "1",
                SpecializationName = "1"
            };

            var serviceDto = new ServiceDto()
            {
                Id = new Guid("d976d96d-94d3-4351-9e36-29389e39154a"),
                Price = 10,
                ServiceName = "1",
                SpecializationName = "1"
            };

            var serviceItems = new Fixture().CreateMany<Service>(19);
            serviceItems = serviceItems.Append(serviceItem);
            serviceItems = serviceItems.Skip(skip).Take(take).AsQueryable();

            var serviceItemsMapped = new Fixture().CreateMany<ServiceDto>(19);
            serviceItemsMapped = serviceItemsMapped.Append(serviceDto);
            serviceItemsMapped =  serviceItemsMapped.Skip(skip).Take(take).AsQueryable();

            repositoryMock.Setup(x => x.Service.GetAllServicesAsync(parameters, false)).ReturnsAsync(serviceItems);
            mapperMock.Setup(x => x.Map<IEnumerable<ServiceDto>>(serviceItems)).Returns(serviceItemsMapped);

            //Act
            var actual = await service.GetAllServicesAsync(parameters);

            //Assert
            Assert.Equal(serviceDto, actual.Last());
        }

        [Fact]
        public async Task GetAllServicesAsync_WithDefaultParameters_ReturnsTenItems()
        {
            //Arrange
            var parameters = new ServiceParameters();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var take = parameters.PageSize;

            var serviceItems = new Fixture().CreateMany<Service>(20).Skip(skip).Take(take).AsQueryable();
            var serviceItemsMapped = new Fixture().CreateMany<ServiceDto>(20).Skip(skip).Take(take).AsQueryable();

            repositoryMock.Setup(x => x.Service.GetAllServicesAsync(parameters, false)).ReturnsAsync(serviceItems);
            mapperMock.Setup(x => x.Map<IEnumerable<ServiceDto>>(serviceItems)).Returns(serviceItemsMapped);

            //Act
            var actual = await service.GetAllServicesAsync(parameters);

            //Assert
            Assert.Equal(parameters.PageSize, actual.ToList().Count);
        }

        [Fact]
        public async Task GetAllServicesAsync_WithParametersEqualZero_ReturnsAllItems()
        {
            //Arrange
            ServiceParameters parameters = null;

            var serviceItems = new Fixture().CreateMany<Service>(20).AsQueryable();
            var serviceItemsMapped = new Fixture().CreateMany<ServiceDto>(20).AsQueryable();

            repositoryMock.Setup(x => x.Service.GetAllServicesAsync(parameters, false)).ReturnsAsync(serviceItems);
            mapperMock.Setup(x => x.Map<IEnumerable<ServiceDto>>(serviceItems)).Returns(serviceItemsMapped);

            //Act
            var actual = await service.GetAllServicesAsync(parameters);

            //Assert
            Assert.Equal(serviceItems.Count(), actual.ToList().Count);
        }

        [Fact]
        public async Task GetAllServicesAsync_WithParametersAboveZero_ReturnsAllItems()
        {
            //Arrange
            var parameters = new ServiceParameters();
            parameters.PageNumber = -1;
            parameters.PageSize = -10;

            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var take = parameters.PageSize;

            var serviceItems = new Fixture().CreateMany<Service>(20).AsQueryable();
            var serviceItemsMapped = new Fixture().CreateMany<ServiceDto>(20).AsQueryable();

            repositoryMock.Setup(x => x.Service.GetAllServicesAsync(parameters, false)).ReturnsAsync(serviceItems);
            mapperMock.Setup(x => x.Map<IEnumerable<ServiceDto>>(serviceItems)).Returns(serviceItemsMapped);

            //Act
            var actual = await service.GetAllServicesAsync(parameters);

            //Assert
            Assert.Equal(serviceItems.Count(), actual.ToList().Count);
        }

        [Fact]
        public async Task CreateServiceAsync_ValidObjectPassed_ReturnsObject()
        {
            //Arrange
            var serviceForcreation = new ServiceForCreationDto();
            var serviceDto = new ServiceDto();
            var serviceEntity = new Service();

            mapperMock.Setup(x => x.Map<Service>(serviceForcreation)).Returns(serviceEntity);
            mapperMock.Setup(x => x.Map<ServiceDto>(serviceEntity)).Returns(serviceDto);
            repositoryMock.Setup(x => x.Service.CreateServiceAsync(serviceEntity));

            //Act
            var actual = await service.CreateServiceAsync(serviceForcreation);

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public async Task CreateServiceAsync_ValidObjectPassed_ReturnsServiceDto()
        {
            //Arrange
            var serviceForcreation = new ServiceForCreationDto()
            {
                ServiceName = "1",
                Price = 10
            };

            var serviceDto = new ServiceDto()
            {
                Id = new Guid("d976d96d-94d3-4351-9e36-29389e39154a"),
                ServiceName = "1",
                Price = 10
            };

            var serviceEntity = new Service()
            {
                Id = new Guid("d976d96d-94d3-4351-9e36-29389e39154a"),
                ServiceName = "1",
                Price = 10
            };

            mapperMock.Setup(x => x.Map<Service>(serviceForcreation)).Returns(serviceEntity);
            mapperMock.Setup(x => x.Map<ServiceDto>(serviceEntity)).Returns(serviceDto);
            repositoryMock.Setup(x => x.Service.CreateServiceAsync(serviceEntity));

            //Act
            var actual = await service.CreateServiceAsync(serviceForcreation);

            //Assert
            Assert.Equal(serviceDto, actual);
            mapperMock.Verify(x => x.Map<ServiceDto>(serviceEntity), Times.Once);
        }

        [Fact]
        public async Task CreateServiceAsync_NullObjectPassed_ThrowsNullReferenceException()
        {
            //Arrange
            ServiceForCreationDto serviceForcreation = null;
            var serviceDto = new ServiceDto();
            var serviceEntity = new Service();
            var createService = async () => await service.CreateServiceAsync(serviceForcreation);

            //Act
            var exception = await Assert.ThrowsAsync<ServiceNullReferenceException>(createService);

            //Assert
            Assert.Equal($"Object of type: {typeof(ServiceForCreationDto).Name} is null.", exception.Message);
        }

        [Fact]
        public async Task GetServiceAsync_ExistingGuidPassed_ReturnsServiceDto()
        {
            //Arrange
            var serviceId = Guid.NewGuid();
            var serviceDto = new ServiceDto();
            var serviceEntity = new Service();

            mapperMock.Setup(x => x.Map<ServiceDto>(serviceEntity)).Returns(serviceDto);
            repositoryMock.Setup(x => x.Service.GetServiceAsync(serviceId, false)).ReturnsAsync(serviceEntity);

            //Act
            var actual = await service.GetServiceAsync(serviceId);

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public async Task GetServiceAsync_NotExistingGuidPassed_ThrowsNotFoundException()
        {
            //Arrange
            Guid serviceId = Guid.Empty;
            var serviceDto = new ServiceDto();
            var serviceEntity = new Service();
            var getService = async () => await service.GetServiceAsync(serviceId);

            mapperMock.Setup(x => x.Map<ServiceDto>(serviceEntity)).Returns(serviceDto);
            repositoryMock.Setup(x => x.Service.GetServiceAsync(serviceId, false));

            //Act
            var exception = await Assert.ThrowsAsync<ServiceNotFoundException>(getService);

            //Assert
            Assert.Equal($"The service with the identifier {serviceId} was not found.", exception.Message);
        }

        [Fact]
        public async Task DeleteServiceAsync_NotExistingGuidPassed_ThrowsNotFoundException()
        {
            //Arrange
            var serviceId = Guid.Empty;
            var serviceEntity = new Service();
            var deleteService = async () => await service.DeleteServiceAsync(serviceId);

            repositoryMock.Setup(x => x.Service.DeleteServiceAsync(serviceEntity));

            //Act
            var exception = await Assert.ThrowsAsync<ServiceNotFoundException>(deleteService);

            //Assert
            Assert.Equal($"The service with the identifier {serviceId} was not found.", exception.Message);
        }

        [Fact]
        public async Task DeleteServiceAsync_ExistingGuidPassed_InvokeMethodOneTime()
        {
            //Arrange
            var serviceEntity = new Fixture().Create<Service>();

            repositoryMock.Setup(x => x.Service.GetServiceAsync(serviceEntity.Id, false)).ReturnsAsync(serviceEntity);
            repositoryMock.Setup(x => x.Service.DeleteServiceAsync(serviceEntity));

            await service.DeleteServiceAsync(serviceEntity.Id);

            //Assert
            repositoryMock.Verify(x => x.Service.DeleteServiceAsync(serviceEntity), Times.Once);
        }

        [Fact]
        public async Task UpdateServiceAsync_ValidParametersPassed_InvokeMethodOneTime()
        {
            //Arrange
            var serviceId = new Guid("d976d96d-94d3-4351-9e36-29389e39154a");
            var serviceForUpdate = new Fixture().Create<ServiceForUpdateDto>();
            var serviceEntity = new Service()
            { 
                Id = serviceId,
                ServiceName = serviceForUpdate.ServiceName,
                Price = serviceForUpdate.Price
            };

            repositoryMock.Setup(x => x.Service.GetServiceAsync(serviceId, true)).ReturnsAsync(serviceEntity);
            mapperMock.Setup(x => x.Map(serviceForUpdate, serviceEntity)).Returns(serviceEntity);

            await service.UpdateServiceAsync(serviceId, serviceForUpdate);

            //Assert
            mapperMock.Verify(x => x.Map(serviceForUpdate, serviceEntity), Times.Once);
            repositoryMock.Verify(x => x.Service.GetServiceAsync(serviceId, true), Times.Once);
        }

        [Fact]
        public async Task UpdateServiceAsync_NotExistingGuidPassed_ThrowsNotFoundException()
        {
            //Arrange
            var serviceId = Guid.Empty;
            var serviceForUpdate = new ServiceForUpdateDto();
            var serviceEntity = new Service();
            var updateService = async () => await service.UpdateServiceAsync(serviceId, serviceForUpdate);

            mapperMock.Setup(x => x.Map<Service>(serviceForUpdate)).Returns(serviceEntity);
            repositoryMock.Setup(x => x.Service.GetServiceAsync(serviceId, false));

            //Act
            var exception = await Assert.ThrowsAsync<ServiceNotFoundException>(updateService);

            //Assert
            Assert.Equal($"The service with the identifier {serviceId} was not found.", exception.Message);
        }

        [Fact]
        public async Task UpdateServiceAsync_NullObjectForCreationPassed_ThrowsNullReferenceException()
        {
            //Arrange
            var serviceId = Guid.NewGuid();
            ServiceForUpdateDto serviceForUpdate = null;
            var serviceEntity = new Service();
            var updateService = async () => await service.UpdateServiceAsync(serviceId, serviceForUpdate);

            mapperMock.Setup(x => x.Map<Service>(serviceForUpdate)).Returns(serviceEntity);

            //Act
            var exception = await Assert.ThrowsAsync<ServiceNullReferenceException>(updateService);

            //Assert
            Assert.Equal($"Object of type: {typeof(ServiceForUpdateDto).Name} is null.", exception.Message);
        }
    }
}
using Moq;
using ServicesAPI.Core.Entities.DataTransferObject;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Entities.QueryParameters;
using ServicesAPI.Core.Exceptions;
using ServicesAPI.Core.Exceptions.UserClassExceptions;
using ServicesAPI.Core.Services.Abstractions.UserServices;

namespace InnoClinic.ServicesAPI.Tests.Services
{
    public class ServiceServiceTest
    {
        private readonly Mock<IServiceService> serviceMock;
        public ServiceServiceTest()
        {
            serviceMock = new Mock<IServiceService>();
        }

        [Fact]
        public async Task GetAllServicesAsync_WithDefaultParameters_ReturnsServiceDtoItems()
        {
            //Arrange
            var servicesDto = new Mock<IEnumerable<ServiceDto>>().Object;
            var parameters = new ServiceParameters();
            serviceMock.Setup(x => x.GetAllServicesAsync(parameters)).ReturnsAsync(servicesDto);
            var service = serviceMock.Object;

            //Act
            var actual = await service.GetAllServicesAsync(parameters);

            //Assert
            Assert.IsAssignableFrom<IEnumerable<ServiceDto>>(actual);
        }

        [Fact]
        public async Task GetServiceAsync_ExistsingGuidPassed_ReturnsServiceDto()
        {
            //Arrange
            var servicesDto = new Mock<ServiceDto>().Object;
            var serviceId = new Guid("8c6d093c-c52c-4a9b-709b-08dac166520c");
            serviceMock.Setup(x => x.GetServiceAsync(serviceId)).ReturnsAsync(servicesDto);
            var service = serviceMock.Object;

            //Act
            var actual = await service.GetServiceAsync(serviceId);

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public async Task GetServiceAsync_InvalidGuidPassed_ReturnsNotFoundRequest()
        {
            //Arrange
            var serviceId = Guid.NewGuid();
            var exception = new ServiceNotFoundException(serviceId);
            serviceMock.Setup(x => x.GetServiceAsync(serviceId)).ThrowsAsync(exception);
            var service = serviceMock.Object;

            //Assert
            await Assert.ThrowsAsync<ServiceNotFoundException>(async () => await service.GetServiceAsync(serviceId));
        }

        [Fact]
        public async Task CreateServiceAsync_ExistsingDtoForCreation_ReturnsServiceDto()
        {
            //Arrange
            var serviceForCreation = new Mock<ServiceForCreationDto>().Object;
            var servicesDto = new Mock<ServiceDto>().Object;
            serviceMock.Setup(x => x.CreateServiceAsync(serviceForCreation)).ReturnsAsync(servicesDto);
            var service = serviceMock.Object;

            //Act
            var actual = await service.CreateServiceAsync(serviceForCreation);

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public async Task CreateServiceAsync_InvalidDtoForCreation_ReturnsBadRequest()
        {
            //Arrange
            var serviceForCreation = new Mock<ServiceForCreationDto>().Object;
            var exception = new ServiceBadRequestException();
            serviceMock.Setup(x => x.CreateServiceAsync(serviceForCreation)).ThrowsAsync(exception);
            var service = serviceMock.Object;

            //Assert
            await Assert.ThrowsAsync<ServiceBadRequestException>(async () => await service.CreateServiceAsync(serviceForCreation));
        }

        [Fact]
        public async Task DeleteServiceAsync_InvalidGuidPassed_ReturnsNotFound()
        {
            //Arrange
            var serviceId = Guid.NewGuid();
            var exception = new ServiceNotFoundException(serviceId);
            serviceMock.Setup(x => x.DeleteServiceAsync(serviceId)).ThrowsAsync(exception);
            var service = serviceMock.Object;

            //Assert
            await Assert.ThrowsAsync<ServiceNotFoundException>(async () => await service.DeleteServiceAsync(serviceId));
        }

        [Fact]
        public async Task UpdateServiceAsync_InvalidGuidPassed_ReturnsNotFound()
        {
            //Arrange
            var serviceId = Guid.NewGuid();
            var exception = new ServiceNotFoundException(serviceId);
            var serviceForUpdateDto = new Mock<ServiceForUpdateDto>().Object;
            serviceMock.Setup(x => x.UpdateServiceAsync(serviceId, serviceForUpdateDto)).ThrowsAsync(exception);
            var service = serviceMock.Object;

            //Assert
            await Assert.ThrowsAsync<ServiceNotFoundException>(async () => await service.UpdateServiceAsync(serviceId, serviceForUpdateDto));
        }
    }
}
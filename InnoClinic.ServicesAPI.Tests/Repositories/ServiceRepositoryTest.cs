using AutoFixture;
using MockQueryable.Moq;
using Moq;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Entities.QueryParameters;
using ServicesAPI.Core.Repository.UserClasses;
using ServicesAPI.Infrastructure.Repository;

namespace InnoClinic.ServicesAPI.Tests.Repositories
{
    public class ServiceRepositoryTest
    {
        [Fact]
        public async Task GetAllServicesAsync_WithDefaultParameters_ReturnsTenItems()
        {
            //Arrange
            ServiceRepository service;
            var services = new Fixture().CreateMany<Service>(20).AsQueryable();
            var repositoryContextMock = services.BuildMockDbSet();
            var parameters = new ServiceParameters();
            var contextMock = new Mock<RepositoryContext>();
            contextMock.Setup(x => x.Set<Service>()).Returns(repositoryContextMock.Object);
            service = new ServiceRepository(contextMock.Object);

            //Act
            var serviceItems = await service.GetAllServicesAsync(parameters);

            //Assert
            Assert.Equal(10, serviceItems.ToList().Count);
        }

        [Fact]
        public async Task GetAllServicesAsync_WithParametersEqualsZero_ReturnsAllItems()
        {
            //Arrange
            ServiceRepository service;
            var services = new Fixture().CreateMany<Service>(20).AsQueryable();
            var repositoryContextMock = services.BuildMockDbSet();
            var parameters = new ServiceParameters();
            parameters.PageNumber = 0;
            parameters.PageSize = 0;
            var contextMock = new Mock<RepositoryContext>();
            contextMock.Setup(x => x.Set<Service>()).Returns(repositoryContextMock.Object);
            service = new ServiceRepository(contextMock.Object);

            //Act
            var serviceItems = await service.GetAllServicesAsync(parameters);

            //Assert
            Assert.Equal(20, serviceItems.ToList().Count);
        }
    }
}

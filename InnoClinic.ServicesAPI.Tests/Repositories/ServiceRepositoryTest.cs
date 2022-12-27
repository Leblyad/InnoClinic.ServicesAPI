using AutoFixture;
using MockQueryable.Moq;
using Moq;
using InnoClinic.ServicesAPI.Core.Entities.Models;
using InnoClinic.ServicesAPI.Core.Entities.QueryParameters;
using InnoClinic.ServicesAPI.Core.Repository.UserClasses;
using InnoClinic.ServicesAPI.Infrastructure.Repository;

namespace InnoClinic.ServicesAPI.Tests.Repositories
{
    public class ServiceRepositoryTest
    {
        private readonly ServiceRepository serviceRepository;
        private readonly Mock<RepositoryContext> repositoryContextMock;
        public ServiceRepositoryTest()
        {
            repositoryContextMock = new Mock<RepositoryContext>();
            serviceRepository = new ServiceRepository(repositoryContextMock.Object);
        }

        [Fact]
        public async Task GetAllServicesAsync_WithDefaultParameters_ReturnsTenItems()
        {
            //Arrange
            var services = new Fixture().CreateMany<Service>(20).AsQueryable();
            var dbSetMock = services.BuildMockDbSet();
            var parameters = new ServiceParameters();

            repositoryContextMock.Setup(x => x.Set<Service>()).Returns(dbSetMock.Object);

            //Act
            var serviceItems = await serviceRepository.GetAllServicesAsync(parameters);

            //Assert
            Assert.Equal(10, serviceItems.ToList().Count);
        }

        [Fact]
        public async Task GetAllServicesAsync_WithParametersEqualsZero_ReturnsAllItems()
        {
            //Arrange
            var services = new Fixture().CreateMany<Service>(20).AsQueryable();
            var dbSetMock = services.BuildMockDbSet();

            var parameters = new ServiceParameters();
            parameters.PageNumber = 0;
            parameters.PageSize = 0;

            repositoryContextMock.Setup(x => x.Set<Service>()).Returns(dbSetMock.Object);

            //Act
            var serviceItems = await serviceRepository.GetAllServicesAsync(parameters);

            //Assert
            Assert.Equal(20, serviceItems.ToList().Count);
        }
    }
}

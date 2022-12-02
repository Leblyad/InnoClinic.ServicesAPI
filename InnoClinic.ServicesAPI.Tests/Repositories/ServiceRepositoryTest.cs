using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Moq;
using ServicesAPI.Core.Contracts.Repositories;
using ServicesAPI.Core.Entities.Models;
using ServicesAPI.Core.Entities.QueryParameters;
using ServicesAPI.Core.Repository.UserClasses;
using ServicesAPI.Core.Services.Abstractions.UserServices;
using ServicesAPI.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoClinic.ServicesAPI.Tests.Repositories
{
    public class ServiceRepositoryTest
    {
        [Fact]
        public async Task GetAllServicesAsync_ValidParameters_ReturnsTenItems()
        {
            //Arrange
            var list = new Fixture().CreateMany<Service>(20).AsQueryable();
            ServiceRepository service;

            var mockSet = new Mock<DbSet<Service>>();

            //mockSet.As<IDbAsyncEnumerable<Service>>()
            //.Setup(m => m.GetAsyncEnumerator());

            //mockSet.As<IQueryable<Service>>()
            //   .Setup(m => m.Provider);

            //mockSet.As<IQueryable<Service>>().Setup(m => m.Provider).Returns(list.Provider);
            //mockSet.As<IQueryable<Service>>().Setup(m => m.Expression).Returns(list.Expression);
            //mockSet.As<IQueryable<Service>>().Setup(m => m.ElementType).Returns(list.ElementType);
            //mockSet.As<IQueryable<Service>>().Setup(m => m.GetEnumerator()).Returns(() => list.GetEnumerator());


            var contextMock = new Mock<RepositoryContext>();
            var parameters = new ServiceParameters();
            contextMock.Setup(x => x.Set<Service>()).Returns(mockSet.Object);
            var context = contextMock.Object;
            service = new ServiceRepository(context);

            //Act
            var serviceItems = await service.GetAllServicesAsync(parameters);

            //Assert
            Assert.NotNull(serviceItems);
        }
    }
}

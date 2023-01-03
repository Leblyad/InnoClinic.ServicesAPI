using InnoClinic.ServicesAPI.Tests.Configuration;
using InnoClinic.ServicesAPI.Application.Entities.DataTransferObject;
using InnoClinic.ServicesAPI.Core.Entities.Models;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace InnoClinic.ServicesAPI.Tests.Controllers
{
    public class ServiceControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient client;

        public ServiceControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            client = factory.CreateClient();
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 5)]
        public async Task GetAllServices_WithValidParameters_ReturnsOk(int pageNumber, int pageSize)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"/api/services" + $"?PageNumber={pageNumber}&PageSize={pageSize}");
            var serviceToCompare = new Service()
            {
                Id = new Guid("8c6d093c-c52c-4a9b-709b-08dac166520c"),
                Price = 100,
                ServiceName = "SomeName1",
                SpecializationId = new Guid("acc08d75-50ea-4689-84cc-bc4b41138301"),
                ServiceCategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
            };

            //Act
            var response = await client.SendAsync(request);
            var servicesList = await response.Content.ReadFromJsonAsync<List<ServiceDto>>();
            var service = servicesList.First();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(service.Id, serviceToCompare.Id);
            Assert.Equal(service.Price, serviceToCompare.Price);
            Assert.Equal(service.Specialization.Id, serviceToCompare.SpecializationId);
            Assert.Equal(service.ServiceName, serviceToCompare.ServiceName);
        }

        [Fact]
        public async Task GetAllServices_WithParametersMoreThanCollection_ReturnsOkAndZeroElements()
        {
            //Arrange
            var pageSize = 20;
            var pageNumber = 20;
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"/api/services" + $"?PageNumber={pageNumber}&PageSize={pageSize}");

            //Act
            var response = await client.SendAsync(request);
            var servicesList = await response.Content.ReadFromJsonAsync<List<ServiceDto>>();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(0, servicesList.Count);
        }

        [Theory]
        [InlineData("0d6b7dc6-b351-4b72-ab6a-08dad78540c0")]
        public async Task GetService_WithExistingId_ReturnsOK(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/services/{serviceId}");
            var serviceToCompare = new Service()
            {
                Id = new Guid("0d6b7dc6-b351-4b72-ab6a-08dad78540c0"),
                Price = 60,
                ServiceName = "SomeName5",
                SpecializationId = new Guid("acc08d75-50ea-4689-84cc-bc4b41138301"),
                ServiceCategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6")
            };

            //Act
            var response = await client.SendAsync(request);
            var service = await response.Content.ReadFromJsonAsync<ServiceDto>();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(service.Id, serviceToCompare.Id);
            Assert.Equal(service.Price, serviceToCompare.Price);
            Assert.Equal(service.Specialization.Id, serviceToCompare.SpecializationId);
            Assert.Equal(service.ServiceName, serviceToCompare.ServiceName);
        }

        [Theory]
        [InlineData("8c6d093c-c52c-4a9a-709b-08dac166520c")]
        public async Task GetService_WithNotExistingId_ReturnsNotFound(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/services/{serviceId}");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateService_WithValidObjectPassed_ReturnsCreated()
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, $"/api/services");

            var service = new ServiceForCreationDto()
            {
                ServiceName = "SomeName",
                Price = 100,
                ServiceCategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                SpecializationId = new Guid("acc08d75-50ea-4689-84cc-bc4b41138301")
            };

            var requestBody = JsonSerializer.Serialize(service);
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            //Act
            var response = await client.SendAsync(request);
            var serviceResponse = await response.Content.ReadFromJsonAsync<ServiceDto>();

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(service.ServiceName, serviceResponse.ServiceName);
            Assert.Equal(service.SpecializationId, serviceResponse.Specialization.Id);
            Assert.Equal(service.Price, serviceResponse.Price);
        }

        [Fact]
        public async Task CreateService_WithInvalidObjectPassed_ReturnsBadRequest()
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Post, $"/api/services");

            var service = new ServiceForCreationDto()
            {
                Price = 100,
                ServiceCategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                SpecializationId = new Guid("acc08d75-50ea-4689-84cc-bc4b41138301"),
            };

            var requestBody = JsonSerializer.Serialize(service);
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("24d92a89-a088-4687-9947-08dac62592e6")]
        public async Task DeleteService_WithExistingIdPassed_ReturnsNoContent(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Delete,
                $"/api/services/{serviceId}");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Theory]
        [InlineData("0")]
        public async Task DeleteService_WithNotExistingIdPassed_ReturnsNotFound(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Delete,
                $"/api/services/{serviceId}");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData("8c6d093c-c52c-4a9b-709b-08dac166520c")]
        public async Task UpdateService_WithExistingIdAndValidObject_ReturnsNoContent(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Put, $"/api/services/{serviceId}");

            var serviceForCreation = new ServiceForCreationDto()
            {
                ServiceName = "NewName",
                Price = 1000,
                ServiceCategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                SpecializationId = new Guid("acc08d75-50ea-4689-84cc-bc4b41138301"),
            };

            var requestBody = JsonSerializer.Serialize(serviceForCreation);
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Theory]
        [InlineData("8c6d093c-c52c-4a9a-709b-08dac166520c")]
        public async Task UpdateService_WithNotExistingIdAndValidObject_ReturnsNotFound(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Put, $"/api/services/{serviceId}");

            var service = new ServiceForCreationDto()
            {
                ServiceName = "SomeName",
                Price = 100,
                ServiceCategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                SpecializationId = new Guid("acc08d75-50ea-4689-84cc-bc4b41138301")
            };

            var requestBody = JsonSerializer.Serialize(service);
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData("8c6d093c-c52c-4a9b-709b-08dac166520c")]
        public async Task UpdateService_WithExistingIdAndInvalidObject_ReturnsBadRequest(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Put, $"/api/services/{serviceId}");

            var service = new ServiceForCreationDto()
            {
                Price = 100,
                ServiceCategoryId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                SpecializationId = new Guid("acc08d75-50ea-4689-84cc-bc4b41138301")
            };

            var requestBody = JsonSerializer.Serialize(service);
            request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

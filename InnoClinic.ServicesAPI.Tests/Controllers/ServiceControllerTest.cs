using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using AutoFixture;
using ServicesAPI.Core.Entities.DataTransferObject;
using System.Text.Json;
using System.Net.Http.Headers;

namespace InnoClinic.ServicesAPI.Tests.Controllers
{
    public class ServiceControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient client;

        public ServiceControllerTest(WebApplicationFactory<Program> factory)
        {
            client = factory.CreateClient();
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Theory]
        [InlineData(0,0)]
        [InlineData(1, 5)]
        [InlineData(5, 10)]
        public async Task GetAllServices_WithValidParameters_ReturnsOk(int pageNumber, int pageSize)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, 
                $"/api/service?PageNumber={pageNumber}&PageSize={pageSize}");

            //Act
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("8c6d093c-c52c-4a9b-709b-08dac166520c")]
        public async Task GetService_WithExistingGuid_ReturnsOK(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/service/{serviceId}");
            
            //Act
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("8c6d093c-c52c-4a9a-709b-08dac166520c")]
        public async Task GetService_WithNotExistingGuid_ReturnsNotFound(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, $"/api/service/{serviceId}");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateService_WithValidObjectPassed_ReturnsCreated()
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Post,
                $"/api/service");

            request.Content = new StringContent(
                "{\"serviceName\":\"string\"," +
                "\"price\":33," +
                "\"specializationName\":\"string\"," +
                "\"serviceCategoryId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}",
                                    Encoding.UTF8,
                                    "application/json");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task CreateService_WithInvalidObjectPassed_ReturnsBadRequest()
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Post,
                $"/api/service");

            request.Content = new StringContent(
                "{\"serviceName\":\"string\"," +
                "\"price\":33," +
                "\"serviceCategoryId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}",
                                    Encoding.UTF8,
                                    "application/json");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData("24d92a89-a088-4687-9947-08dac62592e6")]
        public async Task DeleteService_WithExistingGuidPassed_ReturnsNoContent(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Delete,
                $"/api/service/{serviceId}");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Theory]
        [InlineData("0")]
        public async Task DeleteService_WithNotExistingGuidPassed_ReturnsNotFound(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Delete,
                $"/api/service/{serviceId}");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData("8c6d093c-c52c-4a9b-709b-08dac166520c")]
        public async Task UpdateService_WithExistingGuidAndValidObject_ReturnsNoContent(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Put,
                $"/api/service/{serviceId}");

            request.Content = new StringContent(
                "{\"serviceName\":\"string\"," +
                "\"price\":33," +
                "\"specializationName\":\"string\"," +
                "\"serviceCategoryId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}",
                                    Encoding.UTF8,
                                    "application/json");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Theory]
        [InlineData("8c6d093c-c52c-4a9a-709b-08dac166520c")]
        public async Task UpdateService_WithNotExistingGuidAndValidObject_ReturnsNotFound(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Put,
                $"/api/service/{serviceId}");

            request.Content = new StringContent(
                "{\"serviceName\":\"string\"," +
                "\"price\":33," +
                "\"specializationName\":\"string\"," +
                "\"serviceCategoryId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}",
                                    Encoding.UTF8,
                                    "application/json");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData("8c6d093c-c52c-4a9b-709b-08dac166520c")]
        public async Task UpdateService_WithExistingGuidAndInvalidObject_ReturnsBadRequest(string serviceId)
        {
            //Arrange
            var request = new HttpRequestMessage(HttpMethod.Put,
                $"/api/service/{serviceId}");

            request.Content = new StringContent(
                "{\"serviceName\":\"string\"," +
                "\"price\":33," +
                "\"serviceCategoryId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}",
                                    Encoding.UTF8,
                                    "application/json");

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

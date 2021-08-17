using Moq;
using OneSignalTask.Domain.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace OneSignalTask.Services.Test
{
    public class OneSignalTaskServiceTest : OneSignalTaskServiceTestBase
    {
        [Fact]
        public async Task OneSignalService_GetAppsAsync_ShouldReturnHttpStatusCodeOK()
        {
            //Arrange
            _mockRestClient.Setup(c => c.ExecuteTaskAsync<IEnumerable<App>>(It.IsAny<IRestRequest>())).ReturnsAsync(_mockRestResponseList.Object);
            _mockRestResponseList.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);
            _mockRestResponseList.SetupGet(s => s.IsSuccessful).Returns(true);
            _mockRestResponseList.SetupGet(s => s.Content).Returns("");

            //Act
            await oneSignalService.GetAppsAsync();

            //Assert
            _mockRestClient.Verify(c => c.ExecuteTaskAsync<IEnumerable<App>>(It.IsAny<IRestRequest>()), Times.Once);

        }

        [Fact]
        public async Task OneSignalService_GetAppsAsync_ShouldReturnError()
        {
            //Arrange
            _mockRestClient.Setup(c => c.ExecuteTaskAsync<IEnumerable<App>>(It.IsAny<IRestRequest>())).ReturnsAsync(_mockRestResponseList.Object);
            _mockRestResponseList.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.NotFound);
            _mockRestResponseList.SetupGet(s => s.IsSuccessful).Returns(false);
            _mockRestResponseList.SetupGet(s => s.ErrorMessage).Returns("Error");

            //Assert
            Assert.ThrowsAsync<Exception>(() => oneSignalService.GetAppsAsync());
        }

        [Fact]
        public async Task OneSignalService_GetAppAsync_ShouldReturnHttpStatusCodeOK()
        {
            //Arrange
            _mockRestClient.Setup(c => c.ExecuteTaskAsync<App>(It.IsAny<IRestRequest>())).ReturnsAsync(_mockRestResponseApp.Object);
            _mockRestResponseApp.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);
            _mockRestResponseApp.SetupGet(s => s.IsSuccessful).Returns(true);
            _mockRestResponseApp.SetupGet(s => s.Content).Returns("");

            //Act
            await oneSignalService.GetAppAsync("testId");

            //Assert
            _mockRestClient.Verify(c => c.ExecuteTaskAsync<App>(It.IsAny<IRestRequest>()), Times.Once);

        }

        [Fact]
        public async Task OneSignalService_GetAppAsync_ShouldReturnError()
        {
            //Arrange
            _mockRestClient.Setup(c => c.ExecuteTaskAsync<App>(It.IsAny<IRestRequest>())).ReturnsAsync(_mockRestResponseApp.Object);
            _mockRestResponseApp.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.NotFound);
            _mockRestResponseApp.SetupGet(s => s.IsSuccessful).Returns(false);
            _mockRestResponseApp.SetupGet(s => s.ErrorMessage).Returns("Error");

            //Assert
            Assert.ThrowsAsync<Exception>(() => oneSignalService.GetAppAsync("testId"));
        }

        [Fact]
        public async Task OneSignalService_CreateAppAsync_ShouldReturnApp()
        {
            //Arrange
            _mockRestClient.Setup(c => c.ExecuteTaskAsync<App>(It.IsAny<IRestRequest>())).ReturnsAsync(_mockRestResponseApp.Object);
            _mockRestResponseApp.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);
            _mockRestResponseApp.SetupGet(r => r.Content).Returns(JsonSerializer.Serialize(new App()));
            _mockRestResponseApp.SetupGet(s => s.IsSuccessful).Returns(true);

            //Act
            await oneSignalService.CreateAppAsync(new App());

            //Assert
            _mockRestClient.Verify(c => c.ExecuteTaskAsync<App>(It.IsAny<IRestRequest>()), Times.Once);
        }


        [Fact]
        public async Task OneSignalService_CreateAppAsync_ShouldReturnError()
        {
            //Arrange
            _mockRestClient.Setup(c => c.ExecuteTaskAsync<App>(It.IsAny<IRestRequest>())).ReturnsAsync(_mockRestResponseApp.Object);
            _mockRestResponseApp.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.NotFound);
            _mockRestResponseApp.SetupGet(s => s.IsSuccessful).Returns(false);
            _mockRestResponseApp.SetupGet(s => s.ErrorMessage).Returns("Error");

            //Assert
            Assert.ThrowsAsync<Exception>(() => oneSignalService.CreateAppAsync(new App()));
        }


        [Fact]
        public async Task OneSignalService_UpdateAppAsync_ShouldReturnApp()
        {
            //Arrange
            _mockRestClient.Setup(c => c.ExecuteTaskAsync<App>(It.IsAny<IRestRequest>())).ReturnsAsync(_mockRestResponseApp.Object);
            _mockRestResponseApp.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.OK);
            _mockRestResponseApp.SetupGet(s => s.IsSuccessful).Returns(true);
            _mockRestResponseApp.SetupGet(r => r.Content).Returns(JsonSerializer.Serialize(new App()));

            //Act
            await oneSignalService.UpdateAppAsync(new App());

            //Assert
            _mockRestClient.Verify(c => c.ExecuteTaskAsync<App>(It.IsAny<IRestRequest>()), Times.Once);
        }


        [Fact]
        public async Task OneSignalService_UpdateAppAsync_ShouldReturnError()
        {
            //Arrange
            _mockRestClient.Setup(c => c.ExecuteTaskAsync<App>(It.IsAny<IRestRequest>())).ReturnsAsync(_mockRestResponseApp.Object);
            _mockRestResponseApp.SetupGet(r => r.StatusCode).Returns(HttpStatusCode.NotFound);
            _mockRestResponseApp.SetupGet(s => s.IsSuccessful).Returns(false);
            _mockRestResponseApp.SetupGet(s => s.ErrorMessage).Returns("Error");
            
            //Assert
            Assert.ThrowsAsync<Exception>(() => oneSignalService.UpdateAppAsync(new App()));
        }

    }
}

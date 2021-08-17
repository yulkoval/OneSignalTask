using Microsoft.AspNetCore.Mvc;
using Moq;
using OneSignalTask.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OneSignalTask.Test
{
    public class OneSignalTaskTest : OneSignalTaskTestBase
    {
        [Fact]
        public async Task OneSignalController_Index_ResturnsAViewResult_WithAListOfApps()
        {
            //Arrange
            _mockOneSignalService.Setup(s=>s.GetAppsAsync()).ReturnsAsync(GetTestApps());

            //Act
            var result = await oneSignalController.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var apps = Assert.IsAssignableFrom<IEnumerable<App>>(viewResult.ViewData.Model);
            Assert.Equal(2, apps.Count());
        }

        private List<App> GetTestApps()
        {
            var apps = new List<App>();
            apps.Add(new App()
            {
                Id = "test1-id",
                Name = "test1-name"
            });
            apps.Add(new App()
            {
                Id = "test2-id",
                Name = "test2-name"
            });
            return apps;
        }


        [Fact]
        public async Task OneSignalController_Details_ResturnsBadRequest_WhenIdIsNull()
        {
            //Arrange
            string appId = null;

            //Act
            var result = await oneSignalController.Details(appId);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal("400", badRequestResult.StatusCode.ToString());
        }


        [Fact]
        public async Task OneSignalController_Details_ResturnsNotFound_WhenAppIsNull()
        {
            //Arrange
            _mockOneSignalService.Setup(s => s.GetAppsAsync()).ReturnsAsync(GetTestApps());
            var appId = "not-found-test-id";

            //Act
            var result = await oneSignalController.Details(appId);

            //Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal("404", notFoundResult.StatusCode.ToString());
        }


        [Fact]
        public async Task OneSignalController_Details_ResturnsAViewResult_WithAnApp()
        {
            //Arrange
            var appId = "test1-id";
            _mockOneSignalService.Setup(s => s.GetAppAsync(appId)).ReturnsAsync(new App { Id = appId });

            //Act
            var result = await oneSignalController.Details(appId);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            App app = Assert.IsAssignableFrom<App>(viewResult.ViewData.Model);
            Assert.Equal(appId, app.Id);
        }


        [Fact]
        public async Task OneSignalController_CreatePost_ResturnsAViewResult_WithAnApp()
        {
            //Arrange
            var createdApp = new App()
            {
                ChromeKey = "chromeKey1-id"
            };

            //Act
            var result = await oneSignalController.CreateAsync(createdApp);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            App app = Assert.IsAssignableFrom<App>(viewResult.ViewData.Model);
            Assert.Equal(createdApp, app);
        }


        [Fact]
        public async Task OneSignalController_CreatePost_ResturnsARedirectToIndex_WhenModelStateIsValidAndAppNameIsNotNull()
        {
            //Arrange
            var createdApp = new App()
            {
                Name = "test1-name"
            };
            _mockOneSignalService.Setup(s => s.CreateAppAsync(createdApp));

            //Act
            var result = await oneSignalController.CreateAsync(createdApp);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            _mockOneSignalService.Verify();
        }


        [Fact]
        public async Task OneSignalController_EditGet_ResturnsBadRequest_WhenIdIsNull()
        {
            //Arrange
            string appId = null;

            //Act
            var result = await oneSignalController.Edit(appId);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal("400", badRequestResult.StatusCode.ToString());
        }


        [Fact]
        public async Task OneSignalController_EditGet_ResturnsNotFound_WhenAppIsNull()
        {
            //Arrange
            _mockOneSignalService.Setup(s => s.GetAppsAsync()).ReturnsAsync(GetTestApps());
            var appId = "not-found-test-id";

            //Act
            var result = await oneSignalController.Edit(appId);

            //Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal("404", notFoundResult.StatusCode.ToString());
        }


        [Fact]
        public async Task OneSignalController_EditGet_ResturnsAViewResult_WithAnApp()
        {
            //Arrange
            var appId = "test1-id";
            _mockOneSignalService.Setup(s => s.GetAppAsync(appId)).ReturnsAsync(new App { Id = appId });

            //Act
            var result = await oneSignalController.Edit(appId);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            App app = Assert.IsAssignableFrom<App>(viewResult.ViewData.Model);
            Assert.Equal(appId, app.Id);
        }


        [Fact]
        public async Task OneSignalController_EditPost_ResturnsARedirectToIndex_WhenModelStateIsValidAndAppNameIsNotNull()
        {
            //Arrange
            var editedApp = new App()
            {
                Name = "test1-name"
            };
            _mockOneSignalService.Setup(s => s.UpdateAppAsync(editedApp));

            //Act
            var result = await oneSignalController.Edit(editedApp);

            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            _mockOneSignalService.Verify();
        }


        [Fact]
        public async Task OneSignalController_EditPost_ResturnsAViewResult_WithAnApp()
        {
            //Arrange
            var editedApp = new App()
            {
                ChromeKey = "chromeKey1-id"
            };

            //Act
            var result = await oneSignalController.Edit(editedApp);

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            App app = Assert.IsAssignableFrom<App>(viewResult.ViewData.Model);
            Assert.Equal(editedApp, app);
        }

    }
}

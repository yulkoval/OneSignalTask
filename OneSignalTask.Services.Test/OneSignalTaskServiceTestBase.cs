using Microsoft.Extensions.Options;
using Moq;
using OneSignalTask.Domain.Models;
using OneSignalTask.Services.Infrastructure.Configurations;
using RestSharp;
using System.Collections.Generic;

namespace OneSignalTask.Services.Test
{
    public class OneSignalTaskServiceTestBase
    {
        public Mock<IOptions<OneSignalOptions>> _mockOneSignalApiConfig = new Mock<IOptions<OneSignalOptions>>();
        public Mock<IRestClient> _mockRestClient = new Mock<IRestClient>();
        public Mock<IRestResponse<IEnumerable<App>>> _mockRestResponseList = new Mock<IRestResponse<IEnumerable<App>>>();
        public Mock<IRestResponse<App>> _mockRestResponseApp = new Mock<IRestResponse<App>>();
        public OneSignalService oneSignalService;

        public OneSignalTaskServiceTestBase()
        {
            _mockOneSignalApiConfig.SetupGet(o => o.Value).Returns(new OneSignalOptions
                {
                    BaseUrl = "https://localhost:44376/",
                    ApiKey = "api-key",
                }
            );
            oneSignalService = new OneSignalService(_mockRestClient.Object, _mockOneSignalApiConfig.Object);
        }

    }
}

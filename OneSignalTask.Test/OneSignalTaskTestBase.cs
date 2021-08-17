using Moq;
using OneSignalTask.Controllers;
using OneSignalTask.Services.Interfaces;

namespace OneSignalTask.Test
{
    public class OneSignalTaskTestBase
    {
        public Mock<IOneSignalService> _mockOneSignalService = new Mock<IOneSignalService>();
        public OneSignalController oneSignalController;

        public OneSignalTaskTestBase()
        {
            oneSignalController = new OneSignalController(_mockOneSignalService.Object);
        }
    }
}

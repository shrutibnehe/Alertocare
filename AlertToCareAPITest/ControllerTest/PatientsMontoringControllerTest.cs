using AlertToCareAPITest.ControllerInterfaces;
using AlertToCareAPI.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using AlertToCare.Data;
using Moq;

namespace AlertToCareAPITest.ControllerTest
{
    public class PatientsMontoringControllerTest
    {
        readonly ISudoMonitornigRepo operations = new ISudoMonitornigRepo();
        private readonly Mock<IMonitoringRepo> _MockRepo;

        private readonly PatientsMonitoringController PatientMonitorController;

        public PatientsMontoringControllerTest()
        {
            _MockRepo = new Mock<IMonitoringRepo>();
            PatientMonitorController = new PatientsMonitoringController(_MockRepo.Object);
        }
        [Fact]
        public void CheckVitalsAreGettingOrNotWhenIdIsGiven()
        {
            PatientsMonitoringController controller = new PatientsMonitoringController(operations);
            var actualResponse = controller.CheckVitalsById("P03");
            var okResult = actualResponse.Result as OkObjectResult;
            // Assert

            Assert.Null(okResult);
            //Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public void TestwhethergettingListOfVitalsOrNot()
        {

            var _Controller = PatientMonitorController.GetVitals();
            Assert.NotNull(_Controller);
        }
    }
}

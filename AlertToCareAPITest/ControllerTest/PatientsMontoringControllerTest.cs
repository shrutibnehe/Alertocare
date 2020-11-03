//using AlertToCareAPITest.ControllerInterfaces;
using AlertToCareAPI.Controllers;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using AlertToCare.Data;
using Moq;
using AlertToCareAPITest.RepoTest;
using AlertToCareAPI.Repo;

namespace AlertToCareAPITest.ControllerTest
{
   public class PatientsMontoringControllerTest : InMemoryContext
    {
        private readonly IMonitoringRepo _monitoringRepo;
        private readonly PatientsMonitoringController _patientsMonitoringController;

        public PatientsMontoringControllerTest()
        {
            _monitoringRepo = new MonitorinRepository(Context);
            _patientsMonitoringController = new PatientsMonitoringController(_monitoringRepo);
        }

        [Theory]
        [InlineData("ICU001")]
        public void TestGetAllAlertsWhenICUIDIsValid(string icuID)
        {
            var alertList = _patientsMonitoringController.GetAlerts(icuID);
            Assert.IsType<OkObjectResult>(alertList);
        }

        [Theory]
        [InlineData("ABC456")]
        public void TestGetAllAlertsWhenICUIDIsInvalid(string icuID)
        {
            var alertList = _patientsMonitoringController.GetAlerts(icuID);
            Assert.IsType<OkObjectResult>(alertList);
        }

        [Fact]
        public void TestAlertStatusChange()
        {
            string alertId = "AL002";
            var IsStatusChanged = _patientsMonitoringController.ChangeStatusOfAlert(alertId);
            Assert.IsType<OkObjectResult>(IsStatusChanged);
        }

        [Fact]
        public void TestDeleteAlertForPatientID()
        {
            string patID = "P02";
            var IsPatientDeleted = _patientsMonitoringController.RemoveAlertOfDischargedPat(patID);
            Assert.IsType<OkObjectResult>(IsPatientDeleted);
        }

        [Fact]
        public void TestGetUnOccupiedBedsWhenValidICUID()
        {
            string icuId = "ICU001";
            var bedsList = _patientsMonitoringController.GetUnoccupiedBeds(icuId);
            Assert.IsType<OkObjectResult>(bedsList);
        }

        [Fact]
        public void TestGetUnOccupiedBedsWhenInvalidIcuId()
        {
            string icuId = "ICU002";
            var bedsList = _patientsMonitoringController.GetUnoccupiedBeds(icuId);
            Assert.IsType<BadRequestObjectResult>(bedsList);
        }
    }
}

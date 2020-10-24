using AlertToCare.Data;
using AlertToCareAPI.Controllers;
using AlertToCareAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AlertToCareAPITest.ControllerTest
{
    public class IcuOccupancyControllerTest
    {
        private readonly Mock<IPatientRepo> _MockRepo;

        private readonly IcuOccupancyController OccupancyController;

        public IcuOccupancyControllerTest()
        {
            _MockRepo = new Mock<IPatientRepo>();
            OccupancyController = new IcuOccupancyController(_MockRepo.Object);
        }
        [Fact]
        public void TestGetAllPatients()
        {
            var _Patients = OccupancyController.GetAllPatients();
            Assert.NotNull(_Patients);
            //Assert.IsType<OkObjectResult>(_Patients);
        }

        [Theory]
        [InlineData("P02")]
        [InlineData("P05")]
        public void TestGetPatientById(string Id)
        {
            var _Patients = OccupancyController.GetPatientById(Id);
            Assert.NotNull(_Patients);
        }

        [Fact]
        public void TestAddNewPatient()
        {
            var _Patient = new Patient
            {
                Id = "P06",
                PatientName = "Sam",
                Age = 25,
                ContantNumber = "15678",
                BedId = "B003",
                IcuId = "ICU002"
            };
            var NewPatient = OccupancyController.AddNewPatient(_Patient);
            Assert.NotNull(NewPatient);
            Assert.IsType<NoContentResult>(NewPatient);
        }

        [Fact]
        //[InlineData("P06")]NotFount
        public void TestUpdatePatient()
        {
            var _Patient = new Patient
            {
                Id = "P06",
                PatientName = "Sam",
                Age = 25,
                ContantNumber = "15678",
                BedId = "B003",
                IcuId = "ICU002"
            };
            var NewPatient = OccupancyController.UpdatePatient("P05", _Patient);
            Assert.NotNull(NewPatient);
            Assert.IsType<NotFoundResult>(NewPatient);
        }
        [Fact]
        //[InlineData("P06")]NotFount
        public void RemovePatient()
        {
            var NewPatient = OccupancyController.RemovePatient("P01");
            Assert.NotNull(NewPatient);
            Assert.IsType<NotFoundResult>(NewPatient);
        }
    }
}

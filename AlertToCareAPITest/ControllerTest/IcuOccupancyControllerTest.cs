using AlertToCare.Data;
using AlertToCareAPI.Controllers;
using AlertToCareAPI.Models;
using AlertToCareAPI.Repo;
using AlertToCareAPITest.RepoTest;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AlertToCareAPITest.ControllerTest
{
    public class IcuOccupancyControllerTest:InMemoryContext
    {
        
        private readonly IPatientRepo _repository;
        private readonly IcuOccupancyController occupancyController;
        public IcuOccupancyControllerTest()
        {
           
            _repository = new PatientRepository(Context);
            occupancyController = new IcuOccupancyController(_repository);
        }
        [Fact]
        public void TestGetAllPatients()
        {
            var _Patients = occupancyController.GetAllPatients();
            Assert.NotEmpty(_Patients);
        }

       [Fact]
        public void TestGetPatientWithValidId()
        {
            var _Patients = occupancyController.GetPatientById("P01");
            Assert.IsType<OkObjectResult>(_Patients);
        }
        [Fact]
        public void TestGetPatientWithInValidId()
        {
            var _Patients = occupancyController.GetPatientById("P010");
            Assert.IsType<BadRequestObjectResult>(_Patients);
        }
        [Fact]
        public void TestGetAllAvailableBeds()
        {
            var AvailableBeds = occupancyController.GetAvailableBeds();
            Assert.IsType<OkObjectResult>(AvailableBeds);

        }
        [Fact]
        public void TestGetAllAvailableBedsForSpecificIcu()
        {
            var AvailableBeds = occupancyController.GetAvailableBedsForIcu("ICU001");
            Assert.IsType<OkObjectResult>(AvailableBeds);

        }
        [Fact]
        public void TestWhenThereAreNoAvailableBeds()
        {
            var AvailableBeds = occupancyController.GetAvailableBedsForIcu("ICU002");
            Assert.IsType<BadRequestObjectResult>(AvailableBeds);


        }
        [Fact]
         public void TestAddNewPatientWithValidDetails()
         {
             var _Patient = new Patient
             {
                 Id = "P06",
                 PatientName = "Sam",
                 Age = 25,
                 ContantNumber = "98765409765",
                 BedId = "B003",
                 IcuId = "ICU001"
             };
             var NewPatient = occupancyController.AddNewPatient(_Patient);
          
             Assert.IsType<OkResult>(NewPatient);
         }
        [Fact]
        public void TestAddNewPatientWithSameId()
        {
            var _Patient = new Patient
            {
                Id = "P01",
                PatientName = "Sam",
                Age = 25,
                ContantNumber = "98765409765",
                BedId = "B003",
                IcuId = "ICU001"
            };
            var NewPatient = occupancyController.AddNewPatient(_Patient);

            Assert.IsType<BadRequestObjectResult>(NewPatient);
        }
        [Fact]
        public void TestAddNewPatientWithInvalidBedIdandIcuIdDetails()
        {
            var _Patient = new Patient
            {
                Id = "P06",
                PatientName = "Sam",
                Age = 25,
                ContantNumber = "98765409765",
                BedId = "B0034",
                IcuId = "ICU001"
            };
            var NewPatient = occupancyController.AddNewPatient(_Patient);

            Assert.IsType<BadRequestObjectResult>(NewPatient);
        }
        [Fact]
        public void TestAddNewPatientWithBedIdOccupied()
        {
            var _Patient = new Patient
            {
                Id = "P06",
                PatientName = "Sam",
                Age = 25,
                ContantNumber = "98765409765",
                BedId = "B001",
                IcuId = "ICU001"
            };
            var NewPatient = occupancyController.AddNewPatient(_Patient);
            Assert.IsType<BadRequestObjectResult>(NewPatient);
        }
        [Fact]
        public void TestRemovePatientWithValidDetails()
        {

            var NewPatient = occupancyController.RemovePatient("P01","ICU001");
            Assert.IsType<OkResult>(NewPatient);
        }
        [Fact]
        public void TestRemovePatientWithInValidId()
        {

            var NewPatient = occupancyController.RemovePatient("P0109","ICU001");
            Assert.IsType<NotFoundResult>(NewPatient);
        }
        [Fact]
        public void TestGetPatientInfo()
        {
           var patient= occupancyController.GetPatientInfo("B001", "ICU001");
            Assert.Equal("P01",patient.Id);

        }
    }
}

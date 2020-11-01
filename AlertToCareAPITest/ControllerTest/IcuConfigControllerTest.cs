using AlertToCare.Data;
using AlertToCareAPI.Controllers;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using AlertToCareAPI.Repo;
using AlertToCareAPITest.RepoTest;
using Microsoft.AspNetCore.Mvc;

using Xunit;

namespace AlertToCareAPITest.ControllerTest
{
     public class IcuConfigControllerTest : InMemoryContext
      {
        // private readonly Mock<IIcuConfigurationRepository> _MockRepo;
        // private readonly IcuConfigController IcuController;
        private readonly IIcuConfigurationRepository _repository;
        private readonly IcuConfigController IcuController;

          public IcuConfigControllerTest()
          {
            //_MockRepo = new Mock<IIcuConfigurationRepository>();
            //IcuController = new IcuConfigController(_MockRepo.Object);
            _repository = new IcuConfigrationRepository(Context);
            IcuController = new IcuConfigController(_repository);
          }
       
          [Fact]
          public void TestGetAllICUs()
          {
              var _Icus = IcuController.GetAllIcus();
              Assert.NotEmpty(_Icus);
              
          }
        [Fact]
        public void TestGetSpecificIcu()
        {
            var _Icus = IcuController.GetSpecificIcu("ICU001");
            Assert.IsType<OkObjectResult>(_Icus);
           
        }
        [Fact]
        public void TestGetSpecificIcuWhenIcuNotPresentWithId()
        {
            var _Icus = IcuController.GetSpecificIcu("ICU008");
            Assert.IsType<NotFoundObjectResult>(_Icus);
        }
       
          [Fact]
          public void TestUpdateIcu()
          {
              var NewIcu = new Icu
              {
                  Id = "ICU001",
                  BedCount = 15,
                  LayoutId = "L001"
              };
              var IcuInfo = IcuController.UpdateIcu("ICU001", NewIcu);
              Assert.IsType<OkResult>(IcuInfo);
          }

        [Fact]
        public void TestUpdateIcuWithMismatchInIds()
        {
            var NewIcu = new Icu
            {
                Id = "ICU002",//id mismatch
                BedCount = 15,
                LayoutId = "L001"
            };
            var IcuInfo = IcuController.UpdateIcu("ICU001", NewIcu);//id mismatch
            Assert.IsType<BadRequestObjectResult>(IcuInfo);
        }
        [Fact]
        public void TestUpdateIcuWithIcuIdNotRegistered()
        {
            var NewIcu = new Icu
            {
                Id = "ICU042",
                BedCount = 15,
                LayoutId = "L001"
            };
            var IcuInfo = IcuController.UpdateIcu("ICU042", NewIcu);
            Assert.IsType<NotFoundResult>(IcuInfo);
        }
        [Fact]
          public void TestDeleteIcuWithValidId()
          {
              var _Icu = IcuController.DeleteIcu("ICU001");
              //Assert.NotNull(_Icu);
              Assert.IsType<OkResult>(_Icu);
          }
        [Fact]
        public void TestDeleteIcuWithInValidId()
        {
            var _Icu = IcuController.DeleteIcu("ICU0010");
            //Assert.NotNull(_Icu);
            Assert.IsType<NotFoundResult>(_Icu);
        }
        [Fact]
          public void TestAddIcuWithValidData()
          {
              var NewIcu = new Icu
              {
                  Id = "ICU003",
                  BedCount = 10,
                  LayoutId = "L001"
              };
              var _Icu = IcuController.AddIcu(NewIcu);
              Assert.NotNull(_Icu);
              Assert.IsType<OkObjectResult>(_Icu);
          }
        [Fact]
        public void TestAddWithInValidIcuData()
        {
            var NewIcu = new Icu
            {
                BedCount = 10
                
            };
            var _Icu = IcuController.AddIcu(NewIcu);
           
            Assert.IsType<BadRequestObjectResult>(_Icu);
        }
        [Fact]
        public void TestAddWithLayoutIdNotRegistered()
        {
            var NewIcu = new Icu
            {
                Id="ICU004",
                BedCount = 10,
                LayoutId="L004"

            };
            var _Icu = IcuController.AddIcu(NewIcu);
            Assert.IsType<BadRequestObjectResult>(_Icu);
            Assert.IsNotType<OkObjectResult>(_Icu);
        }
        [Fact]
        public void TestAddWithAddingIcuWithSamePrimaryKey()
        {
            var NewIcu = new Icu
            {
                Id = "ICU001",
                BedCount = 12,
                LayoutId = "L001"

            };
            var _Icu = IcuController.AddIcu(NewIcu);
            Assert.IsType<BadRequestObjectResult>(_Icu);
            Assert.IsNotType<OkObjectResult>(_Icu);
        }
        [Fact]
        public void TestGetAllLayouts()
        {
            var layouts=IcuController.GetAllLayouts();
            Assert.NotEmpty(layouts);
        }
        [Fact]
        public void TestAddBedsWithValidData()
        {
            var addbeds = IcuController.AddBeds("ICU001", 12);
            Assert.IsType<OkResult>(addbeds);
        }
        [Fact]
        public void TestAddBedsWithInValidData()
        {
            var addbeds = IcuController.AddBeds("ICU001", 10);
            Assert.IsType<BadRequestObjectResult>(addbeds);
        }

    }
}

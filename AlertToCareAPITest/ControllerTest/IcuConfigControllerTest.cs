using AlertToCare.Data;
using AlertToCareAPI.Controllers;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using AlertToCareAPI.Repo;
using AlertToCareAPITest.RepoTest;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
            // Assert.NotNull(_Icus);
            Assert.NotEmpty(_Icus);
              
          }
        [Fact]
        public void TestGetSpecificIcu()
        {
            var _Icus = IcuController.GetSpecificIcu("ICU001");
            // Assert.NotNull(_Icus);
            Assert.IsType<OkObjectResult>(_Icus);
           
        }
        [Fact]
        public void TestGetSpecificIcuWhenIcuNotPresentWithId()
        {
            var _Icus = IcuController.GetSpecificIcu("ICU008");
            Assert.IsType<NotFoundObjectResult>(_Icus);
        }

       

       // [Theory]
         // [InlineData("ICU002")]
          //[InlineData("ICU005")]
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

            //Assert.NotNull(IcuInfo);
            //Assert.IsType<NotFoundResult>(IcuInfo);
            //Assert.IsType<OkResult>(IcuInfo);
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
          public void TestAddIcu()
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
    }

    
        
    
}

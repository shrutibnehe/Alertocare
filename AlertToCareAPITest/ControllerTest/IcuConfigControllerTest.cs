using AlertToCare.Data;
using AlertToCareAPI.Controllers;
using AlertToCareAPI.Models;
using AlertToCareAPITest.RepoTest;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace AlertToCareAPITest.ControllerTest
{
    public class IcuConfigControllerTest : InMemoryContext
    {
        private readonly Mock<IIcuConfigurationRepository> _MockRepo;

        private readonly IcuConfigController IcuController;

        public IcuConfigControllerTest()
        {
            _MockRepo = new Mock<IIcuConfigurationRepository>();
            IcuController = new IcuConfigController(_MockRepo.Object);
        }
        [Fact]
        public void TestGetAllICUs()
        {
            var _Icus = IcuController.GetAllIcus();
            Assert.NotNull(_Icus);
            //Assert.IsType<OkResult>(_Icus);
        }

      /*  [Fact]
        public void TestGetBedStatus()
        {
            var _Bed = IcuController.GetSpecificIcu("B002");
            Assert.NotNull(_Bed);
        }
      */
        [Theory]
        [InlineData("ICU002")]
        [InlineData("ICU005")]
        public void TestUpdateIcu(string Id)
        {
            var NewIcu = new Icu
            {
                Id = "ICU006",
                BedCount = 10,
                LayoutId = "L003"
            };
            var IcuInfo = IcuController.UpdateIcu(Id, NewIcu);
            Assert.NotNull(IcuInfo);
            Assert.IsType<NotFoundResult>(IcuInfo);
        }

        [Fact]
        public void TestDeleteIcu()
        {
            var _Icu = IcuController.DeleteIcu("ICU002");
            Assert.NotNull(_Icu);
        }
        [Fact]
        public void TestAddIcu()
        {
            var NewIcu = new Icu
            {
                Id = "ICU002",
                BedCount = 10,
                LayoutId = "L003"
            };
            var _Icu = IcuController.AddIcu(NewIcu);
            Assert.NotNull(_Icu);
            Assert.IsType<NoContentResult>(_Icu);
        }
    }
}

using AlertToCareAPI.Models;
using AlertToCareAPI.Repo;
using System.Linq;
using Xunit;

namespace AlertToCareAPITest.RepoTest
{
    public class IcuConfigtest : AlertToCareAPITest.RepoTest.InMemoryContext
    {
        [Fact]
        public void CheckAddIcuSuccessful()
        {
            var NewIcu = new Icu
            {
                Id = "ICU004",
                LayoutId = "L004",
                BedCount = 5
            };
            var IcuData = new IcuConfigrationRepository(Context);
            IcuData.AddNewIcu(NewIcu);
            var IcuDataInDb = Context.IcusInfo.FirstOrDefault
                (p => p.BedCount == 5);
            Assert.NotNull(IcuDataInDb);
        }

        [Fact]
        public void CheckAddIcuUnSuccessful()
        {
            var NewIcu = new Icu();
            NewIcu = null;
            var IcuData = new IcuConfigrationRepository(Context);
            //IcuData.AddNewIcu(NewIcu);
            //  var IcuDataInDb = Context.IcusInfo.FirstOrDefault
            //    (p => p.BedCount == 5);
            Assert.Throws<System.ArgumentNullException>(() => IcuData.AddNewIcu(NewIcu));
        }

        [Fact]
        public void CheckWeatherWeGetListOfAllIcus()
        {
            var IcuData = new IcuConfigrationRepository(Context);
            var _Icus = IcuData.GetAllIcus();
            Assert.NotNull(_Icus);
        }

        [Theory]
        [InlineData("ICU002")]
        [InlineData("ICU001")]
        public void CheckWhetherWeGetBedCountWhenIdIsGiven(string IcuId)
        {
            var _IcuInfo = new IcuConfigrationRepository(Context);
            var _Icu = new Icu();
            _Icu = _IcuInfo.GetIcuById(IcuId);
            //string _ExpectedIcuId = _Patient.IcuId;
            if (IcuId == "ICU001")
                Assert.Null(_Icu);
            else
                Assert.Equal(4, _Icu.BedCount);
        }

        [Fact]
        public void CheckForIcuRemoval()
        {
            var _IcuData = new IcuConfigrationRepository(Context);
            var _Icu = _IcuData.GetIcuById("ICU002");
            Assert.NotNull(_Icu);
            _IcuData.RemoveIcu(_Icu);

            Assert.NotNull(_IcuData.GetIcuById("ICU002"));

        }
        [Fact]
        public void WhenRemovingIcuIfIcuIsNullThenThrowsException()
        {
            var NewIcu = new Icu();
            NewIcu = null;
            var IcuData = new IcuConfigrationRepository(Context);
            //IcuData.AddNewIcu(NewIcu);
            //  var IcuDataInDb = Context.IcusInfo.FirstOrDefault
            //    (p => p.BedCount == 5);
            Assert.Throws<System.ArgumentNullException>(() => IcuData.RemoveIcu(NewIcu));
        }
        [Fact]
        public void CheckSaveChanges()
        {
            var _Icu = new IcuConfigrationRepository(Context);
            Assert.True(_Icu.SaveChanges());
        }
    }
}

using Xunit;
using AlertToCareAPI.Repo;

namespace AlertToCareAPITest.RepoTest
{
    public class MonetoringRepoTest : AlertToCareAPITest.RepoTest.InMemoryContext
    {
       /* [Fact]
        public void CheckGettingAlertForBPMorNot()
        {

        }

        [Fact]
        public void CheckWhetherWeAreGettingAllVitalsOrNot()
        {
            var VitalInfo = new MonitorinRepository(Context);
            var AllVitals = VitalInfo.GetAllVitals();
            Assert.NotNull(AllVitals);
        }

        [Fact]
        public void CheckVitalIsGettingOrNotIfWeProvideId()
        {
            var VitalInfo = new MonitorinRepository(Context);
            var _Vital = VitalInfo.GetVitalsById("P03");
            Assert.Equal(70, _Vital.Bpm);
        }

        [Fact]
        public void CheckForAlerter()
        {
            var _Alert = new EmailAlert();
            Assert.True(_Alert.Alert("Vitals are normal"));
        }

        //[Fact]
        //public void CheckIndividuallVitals()
        //{
        //    var VitalInfo = new MonitorinRepository(Context);
        //    var _Vital = new Vital();
        //    Assert.True(VitalInfo.CheckVitals(_Vital));
        //}*/
    }
}

using AlertToCareAPI.ControllerTest;
using System;
using System.Collections.Generic;
using AlertToCareAPI.Models;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using System.Net.Http;

namespace AlertToCareAPITest.IntegrationTests
{
    public class OccupancyTests
    {
       /* private readonly TestClientProvider _test;
        private static string url = "http://localhost:5000/api/IcuOccupancy";
        public OccupancyTests()
        {
            _test = new TestClientProvider();
        }
        [Fact]
        public async Task TestGetAllPatientsData()
        {
            var response = await _test.Client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task TestPostNewPatientWithInValidData()
        {
            var patient = new Patient()
            {
                Id="P012",
                PatientName="TIM",
                Age=23,
                ContantNumber="7894562091",
                BedId="B0012",//invalid bed id
                IcuId="ICU002"


            };
            var response = await _test.Client.PostAsync(url,
                 new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task TestPostNewPatientWithInValidPatientIdData()
        {
            var patient = new Patient()
            {
                Id = "P01",
                PatientName = "TIM",
                Age = 23,
                ContantNumber = "7894562091",
                BedId = "B0012",
                IcuId = "ICU001"


            };
            var response = await _test.Client.PostAsync(url,
                 new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task TestGetPatientById()
        {

            var response = await _test.Client.GetAsync(url + "/P01");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task TestGetAllIcu()
        {

            var response = await _test.Client.GetAsync("http://localhost:5000/api/IcuConfig");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        /*[Fact]
        public async Task TestPostPatientWithValidData()
        {
            var patient = new Patient()
            {
                Id = "P0123",
                PatientName = "TIM",
                Age = 23,
                ContantNumber = "7894562091",
                BedId = "B0012",
                IcuId = "ICU001"


            };
            var response = await _test.Client.PostAsync(url,
                 new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }*/
       /* [Fact]
        public async Task TestGetPatientInfoBasedOnBedAndIcuId()
        {
            var response = await _test.Client.GetAsync(url+"/Patient/B001/ICU001");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }*/
    }
}

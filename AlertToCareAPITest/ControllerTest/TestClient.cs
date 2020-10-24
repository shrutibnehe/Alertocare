using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using AlerToCareAPI;

namespace AlertToCareAPI.ControllerTest
{
    internal class TestClientProvider
    {
        public HttpClient Client { get; set; }
        private TestServer _server;

        public TestClientProvider()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AlertToCareUI.Models;
using AlertToCareUI.ViewModel;

namespace AlertToCareUI.ServiceAccessPoint
{
    class RequestHandler
    {
        public async Task GetAlerts(AlertManagerViewModel alertContext)
        {
           // string icuID = alertContext.ICUID;
            string icuID = "ICU001";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responseMessage = await client.GetAsync("api/patientsmonitoring/ICU001");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonContent = responseMessage.Content.ReadAsStringAsync().Result;
                alertContext.ListOfAlerts = JsonConvert.DeserializeObject<List<Alert>>(jsonContent);
                //MessageBox.Show(alertContext.ListOfAlerts.Count.ToString());

            }
            else
            {
                MessageBox.Show("response not as expected");
            }
        }
        public async Task ChangeAlertStatus(string id, AlertManagerViewModel alertContext)
        {
            string icuID = alertContext.ICUID;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responseMessage = await client.GetAsync($"api/patientsmonitoring/{icuID}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                MessageBox.Show("Alerts Status is Changed");
                await GetAlerts(alertContext);

            }
            else
            {
                MessageBox.Show("response not as expected, ID may be wrong");
            }

        }
    }
}

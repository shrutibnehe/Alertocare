using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using AlertToCareUI.Models;
using AlertToCareUI.ViewModel;

namespace AlertToCareUI.ServiceAccessPoint
{
    class RequestHandler
    {
        static string icuID;
        public async Task GetAlerts(AlertManagerViewModel alertContext)
        {
            icuID = alertContext.ICUID;
            //string icuID = "ICU001";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"api/patientsmonitoring/{icuID}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonContent = responseMessage.Content.ReadAsStringAsync().Result;
                    alertContext.ListOfAlerts = JsonConvert.DeserializeObject<List<Alert>>(jsonContent);
                }
                else
                {
                    MessageBox.Show("No Alerts. \nIf it is wrong message then call Philips");
                }
            }
            catch
            {
                MessageBox.Show("Error in Connection");
            }
            
        }
        public async Task ChangeAlertStatus(string id, AlertManagerViewModel alertContext)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"api/patientsmonitoring/disable/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Alerts Status is Changed");
                    //await GetAlerts(alertContext);
                }
                else
                {
                    MessageBox.Show("ID may be wrong, Please check if the alert is still there.");
                    //await GetAlerts(alertContext);
                }
            }
            catch
            {
                MessageBox.Show("Error in Connection");
            }
           
        }
        public async Task DeleteAlertsOnDischarge(string patientId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage responseMessage = await client.DeleteAsync($"api/patientsmonitoring/{patientId}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    MessageBox.Show("Alerts for Discharged Patients removed");
                }
                else
                {
                    MessageBox.Show("Alerts not deleted for discharged patients");
                }
            }
            catch
            {
                MessageBox.Show("Error in Connection");
            }

        }
        /*public async Task GetUnoccupiedBeds(AlertManagerViewModel alertContext)
        {
            string icuID = alertContext.ICUID;
            //string icuID = "ICU001";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"api/patientsmonitoring/Unoccbed/{icuID}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonContent = responseMessage.Content.ReadAsStringAsync().Result;
                    alertContext.UnoccupiedBeds = JsonConvert.DeserializeObject<List<Bed>>(jsonContent);
                }
                else
                {
                    MessageBox.Show("ICU is Full :\n If not so -Problem in installation. Call Philips.");
                }
            }
            catch
            {
                MessageBox.Show("Error in Connection");
            }
            
        }*/

    }
}

﻿using AlertToCareUI.Models;
using Newtonsoft.Json;

using System.IO;

using System.Net;

using System.Windows;
using System.Windows.Controls;


namespace AlertToCareUI.Views
{
    /// <summary>
    /// Interaction logic for Rectangular_10.xaml
    /// </summary>
    public partial class Rectangular_10 : UserControl
    {
        public Rectangular_10()
        {
            InitializeComponent();
        }
        static string IcuNo;
        public Rectangular_10(string IcuId)
        {
            IcuNo = IcuId;
        }

        private void PatientInfo(object sender, RoutedEventArgs e)
        {
            string b = (string)((Button)sender).Content;
            string icu = IcuNo;

            HttpWebRequest _httpReq = WebRequest.CreateHttp("http://localhost:5000/api/IcuOccupancy/Patient/" + b + "/" + icu);
            _httpReq.Method = "GET";
            HttpWebResponse response = _httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                var result = reader.ReadToEnd();
                var patient = JsonConvert.DeserializeObject<PatientModel>(result);
                MessageBox.Show($"Occupied By PatientNo {patient.Id}");
            }
            else
            {
                MessageBox.Show("Bed Un Occupied");
            }
        }
    }
}

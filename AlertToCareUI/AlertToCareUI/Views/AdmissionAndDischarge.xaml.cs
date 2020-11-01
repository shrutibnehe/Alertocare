using AlertToCareUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlertToCareUI.Views
{
    /// <summary>
    /// Interaction logic for AdmissionAndDischarge.xaml
    /// </summary>
    public partial class AdmissionAndDischarge : UserControl
    {
        public AdmissionAndDischarge()
        {
            InitializeComponent();
        }
        static string IcuNo;
        public AdmissionAndDischarge(string icuid)
        {
            IcuNo = icuid;
        }
        private static readonly HttpClient Client = new HttpClient();
       
      /*  public string IcuNo
        {
            get;set;
        }*/

        private void Admit(object sender, RoutedEventArgs e)
        {
            PatientAdmission();
            
        }
      


        private void PatientAdmission()
        {


            var newPatient = new PatientModel()
            {
                Id = id.Text,
                PatientName = name.Text,
                //Age = int.Parse(age.Text),
                BedId = bedno.Text,
                //IcuId = icuid.Text,
                IcuId = IcuNo,
                ContantNumber = contact.Text
            };
           
            bool response = CheckValidityOfDetails(newPatient);
            if (response == true)
            {
                
                newPatient.Age = int.Parse(age.Text);
                AddToDb(newPatient);

            }
            else
            {
                MessageBox.Show("Please Enter All Valid Details");
            }

        }

        private void AddToDb(PatientModel newPatient)
        {
           
            System.Net.HttpWebRequest _httpReq =
                 System.Net.WebRequest.CreateHttp("http://localhost:5000/api/icuoccupancy");
            _httpReq.Method = "POST";
            _httpReq.ContentType = "application/json";
            DataContractJsonSerializer filterDataJsonSerializer = new DataContractJsonSerializer(typeof(PatientModel));
            filterDataJsonSerializer.WriteObject(_httpReq.GetRequestStream(), newPatient);
            try
            {
                System.Net.HttpWebResponse response = _httpReq.GetResponse() as System.Net.HttpWebResponse;
                // MessageBox.Show($"{response.StatusCode}");
                MessageBox.Show("Patient Registered Successfully");
            }
            catch (Exception)
            {
                //MessageBox.Show($"{ exception.Message}");
                MessageBox.Show("Please Ensure Correct Deatils of Patient ID And BedNo");
            }
        }

        private bool CheckValidityOfDetails(PatientModel newPatient)
        {
            if (String.IsNullOrEmpty(newPatient.Id) || String.IsNullOrEmpty(newPatient.PatientName))
            {
                return false;
            }
            return CheckBedIdAndIcuId(newPatient);
        }

        private bool CheckBedIdAndIcuId(PatientModel newPatient)
        {
            if (String.IsNullOrEmpty(newPatient.BedId) || String.IsNullOrEmpty(newPatient.IcuId))
            {
                return false;
            }
            return CheckContactNo(newPatient);
        }

        private bool CheckContactNo(PatientModel newPatient)
        {
            if (String.IsNullOrEmpty(newPatient.ContantNumber) || newPatient.ContantNumber.Length != 10)
            {
                return false;
            }
            return CheckAge();
        }

        private bool CheckAge()
        {
            try
            {
                int a = int.Parse(age.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        private void Discharge(object sender, RoutedEventArgs e)
        {
            dischargepatient();
        }

        private void dischargepatient()
        {
            if (CheckId(patientid.Text))
            {
                RemovePatient(patientid.Text);
            }
            else
            {
                MessageBox.Show("Please Enter Patient Id To Be discharged");
            }
        }

        private void RemovePatient(string IdDischarged)
        {
            string IcuId = IcuNo;
            System.Net.HttpWebRequest _httpReq =
                System.Net.WebRequest.CreateHttp("http://localhost:5000/api/icuoccupancy/" + IdDischarged + "/" + IcuId);
            _httpReq.Method = "DELETE";

            try
            {
                System.Net.HttpWebResponse response = _httpReq.GetResponse() as System.Net.HttpWebResponse;
                //MessageBox.Show($"{response.StatusCode}");
                MessageBox.Show("Patient Discharged Successfully");
                patientid.Text = "";
            }
            catch (Exception exception)
            {
                //MessageBox.Show($"{exception.Message}");
                MessageBox.Show("InValid Patient Id Entered");
                patientid.Text = "";
            }
        }

        private bool CheckId(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return false;
            }
            return true;

        }
    }
}

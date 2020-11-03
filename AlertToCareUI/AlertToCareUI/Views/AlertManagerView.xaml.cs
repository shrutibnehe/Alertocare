using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AlertToCareUI.ViewModel;
using AlertToCareUI.ServiceAccessPoint;
using System.Collections.Generic;

namespace AlertToCareUI.Views
{
    /// <summary>
    /// Interaction logic for AlertManagerView.xaml
    /// </summary>
    public partial class AlertManagerView : UserControl
    {
        AlertManagerViewModel alertManagerContext = new AlertManagerViewModel();
        RequestHandler requestHandlerObj = new RequestHandler();
        public AlertManagerView()
        {
            InitializeComponent();
            this.DataContext = alertManagerContext;
            GetContinuousAlerts();
        }
        /*public AlertManagerView(string Icuid)
        {
            InitializeComponent();
            alertManagerContext.ICUID = Icuid;
            this.DataContext = alertManagerContext;
            GetContinuousAlerts();
        }*/

        private async void GetContinuousAlerts()
        {
            try
            {
                cmbICU.ItemsSource = new List<string> { "ICU001", "ICU002", "ICU003", "ICU004" };
                while (cmbICU.SelectedItem!=null)
                {
                    alertManagerContext.ICUID = cmbICU.SelectedItem.ToString();
                    await requestHandlerObj.GetAlerts(alertManagerContext);
                    await Task.Delay(5000);
                }
            }
            catch
            {
                 MessageBox.Show("Check Connection with Server. Make Sure It's ON.");
            }
        }

        private void cmbBeds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbBeds.SelectedItem !=null && cmbBeds.SelectedItem.ToString()!= "Loading Beds")
            {
                alertManagerContext.PopulateAlertsOnSelectedBed(cmbBeds.SelectedItem.ToString());
            }
        }

        private void cmbAlerts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbAlerts.SelectedItem != null && cmbBeds.SelectedItem.ToString() != "Loading Alerts")
            {
                alertManagerContext.PopulateDisplayMessage(cmbAlerts.SelectedItem.ToString());
            }
        }

        private async void btnDisable_Click(object sender, RoutedEventArgs e)
        {
            await requestHandlerObj.ChangeAlertStatus(cmbAlerts.Text, alertManagerContext);
        }

        private async void btnUndoDisable_Click(object sender, RoutedEventArgs e)
        {
            await requestHandlerObj.ChangeAlertStatus(cmbAlerts.Text, alertManagerContext);
        }

        private void cmbICU_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetContinuousAlerts();
        }
    }
}

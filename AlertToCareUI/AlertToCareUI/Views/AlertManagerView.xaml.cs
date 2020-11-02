using System;
using System.Collections.Generic;
using System.Linq;
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
using AlertToCareUI.Models;
using AlertToCareUI.ViewModel;
using AlertToCareUI.ServiceAccessPoint;

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
        public AlertManagerView(string Icuid)
        {

            InitializeComponent();
            alertManagerContext.ICUID = Icuid;
            this.DataContext = alertManagerContext;
            GetContinuousAlerts();
        }

        private async void GetContinuousAlerts()
        {
            while (true)
            { 
                await requestHandlerObj.GetAlerts(alertManagerContext);
                await Task.Delay(5000);
                
            }
        }

        private void cmbBeds_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbBeds.SelectedItem !=null)
            {
                alertManagerContext.PopulateAlertsOnSelectedBed(cmbBeds.SelectedItem.ToString());
            }
        }

        private void cmbAlerts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbAlerts.SelectedItem != null)
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
    }
}

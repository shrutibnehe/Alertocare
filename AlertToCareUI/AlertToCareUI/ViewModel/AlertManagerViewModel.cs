using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlertToCareUI.Models;


namespace AlertToCareUI.ViewModel
{
  public  class AlertManagerViewModel : INotifyPropertyChanged
    {
        #region fields

        private List<Alert> _listOfAlerts;
        private List<string> _bedsWithAlerts = new List<string> { "Loading Beds" };
        private List<string> _alertOnSelectedBed = new List<string> { "Loading Alerts" };
        private string _displayMessage = "testMessage";
        #endregion

        #region Properties
        public List<Alert> ListOfAlerts { get { return this._listOfAlerts; } set { this._listOfAlerts = value; this.PopulateBedsWithAlerts(); } }
        public List<string> BedsWithAlerts { get { return this._bedsWithAlerts; } set { this._bedsWithAlerts = value; this.OnPropertyChanged("BedsWithAlerts"); } }
        public List<string> AlertOnSelectedBed { get { return this._alertOnSelectedBed; } set { this._alertOnSelectedBed = value; this.OnPropertyChanged("AlertOnSelectedBed"); } }
        public string DisplayMessage { get { return this._displayMessage; } set { this._displayMessage = value; this.OnPropertyChanged("DisplayMessage"); } }
        public string ICUID { get; set; }
        #endregion

        #region Logics
        public void PopulateBedsWithAlerts()
        {
            List<string> bedsWithAlerts = new List<string> { };
            foreach (var alert in ListOfAlerts)
            {
                if (!bedsWithAlerts.Contains(alert.BedId))
                {

                    bedsWithAlerts.Add(alert.BedId);
                }
            }
            BedsWithAlerts = bedsWithAlerts;

        }

        public void PopulateAlertsOnSelectedBed(string selectedBed)
        {
            List<string> alertsOnSelectedBed = new List<string> { };
            //MessageBox.Show(selectedBed);
            foreach (var alert in ListOfAlerts)
            {
                if (alert.BedId == selectedBed)
                {
                    //MessageBox.Show(alertsOnSelectedBed.Count().ToString());
                    alertsOnSelectedBed.Add(alert.Id);
                }
            }
            //MessageBox.Show(alertsOnSelectedBed.Count().ToString());
            AlertOnSelectedBed = alertsOnSelectedBed;
        }

        public void PopulateDisplayMessage(string selectedAlert)
        {
            foreach (var alert in ListOfAlerts)
            {
                if (alert.Id == selectedAlert)
                {

                    DisplayMessage = alert.Message;
                    //MessageBox.Show(DisplayMessage);
                    break;
                }
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

using System.Collections.Generic;
using System.ComponentModel;
using AlertToCareUI.Models;
using AlertToCareUI.ServiceAccessPoint;

namespace AlertToCareUI.ViewModel
{
  public  class AlertManagerViewModel : INotifyPropertyChanged
    {
        #region fields

        private List<Alert> _listOfAlerts = new List<Alert> { };
        private List<string> _bedsWithAlerts = new List<string> { "Loading Beds" };
        private List<string> _alertOnSelectedBed = new List<string> { "Loading Alerts" };
        private string _displayMessage = " ";
        //private List<Bed> _unoccupiedBeds = new List<Bed> { };
        #endregion

        #region Properties
        public List<Alert> ListOfAlerts { get { return this._listOfAlerts; } 
            set { this._listOfAlerts = value;
                this.PopulateBedsWithAlerts(); } }

        public List<string> BedsWithAlerts { get { return this._bedsWithAlerts; } 
            set { this._bedsWithAlerts = value; this.OnPropertyChanged("BedsWithAlerts"); } }
        public List<string> AlertOnSelectedBed { get { return this._alertOnSelectedBed; } set { this._alertOnSelectedBed = value; this.OnPropertyChanged("AlertOnSelectedBed"); } }
        public string DisplayMessage { get { return this._displayMessage; } set { this._displayMessage = value; this.OnPropertyChanged("DisplayMessage"); } }
        public string ICUID { get; set; }
        //public List<Bed> UnoccupiedBeds { get { return this._unoccupiedBeds; } set { this._unoccupiedBeds = value; } }
        #endregion

        #region Logics
        public void PopulateBedsWithAlerts()
        {
            List<string> bedsWithAlerts = new List<string> { "Loading Beds" };
            foreach (var alert in ListOfAlerts)
            {
                if (!bedsWithAlerts.Contains(alert.BedId))
                {
                    bedsWithAlerts.Remove("Loading Beds");
                    bedsWithAlerts.Add(alert.BedId);
                }
            }
            //bedsWithAlerts = RemoveUnoccupiedBeds(bedsWithAlerts);

            BedsWithAlerts = bedsWithAlerts;

        }

        public void PopulateAlertsOnSelectedBed(string selectedBed)
        {
            List<string> alertsOnSelectedBed = new List<string> { "Loading Alerts" };
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

        /*public List<string> RemoveUnoccupiedBeds(List<string> bedsWithAlerts)
        {
            foreach(var bed in UnoccupiedBeds)
            {
                string idToSearch = bed.BedNo;
                if (bedsWithAlerts.Contains(idToSearch))
                {
                    bedsWithAlerts.Remove(idToSearch);
                }
            }
            return bedsWithAlerts;
        }*/
        
        /*public async void GetUnoccBeds()
        {
            RequestHandler requestHandler = new RequestHandler();
            await requestHandler.GetUnoccupiedBeds(this);
        }*/

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

using AlertToCareAPI.Models;
using System.Collections.Generic;

namespace AlertToCare.Data
{

    public interface IMonitoringRepo
    {
        public IEnumerable<Alert> GetAllActiveAlerts(string icuID);
        public bool AlertChangeStatus(string id);
        public void RemoveAlertsOfPatient(string id);

        public bool SaveChanges();
    }
}

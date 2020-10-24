using AlertToCareAPI.Models;
using System.Collections.Generic;

namespace AlertToCare.Data
{

    public interface IMonitoringRepo
    {
        public bool CheckVitals(Vital vital);
        Vital GetVitalsById(string id);
        public IEnumerable<Vital> GetAllVitals();
    }
}

using System;
using System.Collections.Generic;
using AlertToCareAPI.Models;
using AlertToCare.Data;

namespace AlertToCareAPITest.ControllerInterfaces
{
    class ISudoMonitornigRepo : IMonitoringRepo
    {
        public bool CheckVitals(Vital vital)
        {
            vital.Id = "P03";
            if (vital.Bpm == 90)
                return false;
            return true;
        }

        public IEnumerable<Vital> GetAllVitals()
        {
            throw new NotImplementedException();
        }

        public Vital GetVitalsById(string id)
        {
            var _Vital = new Vital
            {
                Id = id,
                Bpm = 70,
                RespRate = 111,
                Spo2 = 99
            };
            return _Vital;
        }
    }
}

using AlertToCare.Data;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AlertToCareAPI.Repo
{
    public class MonitorinRepository : IMonitoringRepo
    {
        public List<double> upperLimit = new List<double>();
        public List<double> lowerLimit = new List<double>();
        public Alerter alerter = new EmailAlert();

        private readonly DataContext _context;

        public MonitorinRepository(DataContext context)
        {
            _context = context;

            //upper and lower limit of bpm
            upperLimit.Add(150);
            lowerLimit.Add(70);
            //upper and lower limit of spo2
            upperLimit.Add(int.MaxValue);
            lowerLimit.Add(90);
            //upper and lower linit of resp rate
            upperLimit.Add(95);
            lowerLimit.Add(30);
        }
        [ExcludeFromCodeCoverage]
        public void AlertForBPM(double upperLimit, double lowerLimit, double value, string patientId, string icuId)
        {
            if (value < lowerLimit || value > upperLimit)
            {
                var message = "Patient's id: " + patientId + "in the ICU :" + icuId + "has crossed the threshold of BPM and needs immediate attention.";
                alerter.Alert(message);
            }
        }
        [ExcludeFromCodeCoverage]
        public void AlertForSpo2(double upperLimit, double lowerLimit, double value, string patientId, string icuId)
        {
            if (value < lowerLimit || value > upperLimit)
            {
                var message = "Patient's id: " + patientId + "in the ICU :" + icuId + "has crossed the threshold of Spo2 and needs immediate attention.";
                alerter.Alert(message);
            }
        }
        [ExcludeFromCodeCoverage]
        public void AlertForRR(double upperLimit, double lowerLimit, double value, string patientId, string icuId)
        {
            if (value < lowerLimit || value > upperLimit)
            {
                var message = "Patient's id: " + patientId + "in the ICU :" + icuId + "has crossed the threshold of RespRate and needs immediate attention.";
                alerter.Alert(message);
            }
        }
        public IEnumerable<Vital> GetAllVitals()
        {
            var _vitals = _context.VitalsInfo.ToList();

            return _vitals;
        }
        [ExcludeFromCodeCoverage]
        public bool CheckVitals(Vital vital)
        {
            var patientId = vital.Id;
            var patientModel = _context.PatientsInfo.Find(patientId);
            var icuId = patientModel.IcuId;


            AlertForBPM(upperLimit[0], lowerLimit[0], vital.Bpm, patientId, icuId);

            AlertForSpo2(upperLimit[1], lowerLimit[1], vital.Spo2, patientId, icuId);

            AlertForRR(upperLimit[2], lowerLimit[2], vital.RespRate, patientId, icuId);

            return true;
        }

        public Vital GetVitalsById(string id)
        {
            return _context.VitalsInfo.Find(id);
        }
    }
}

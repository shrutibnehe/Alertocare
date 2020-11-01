using AlertToCareAPI.Models;
using System.Collections.Generic;

namespace AlertToCare.Data
{
    public interface IPatientRepo
    {
        bool SaveChanges();

        Patient GetPatientById(string id);
        public bool AddNewPatient(Patient patient);
        public void RemovePatient(Patient patient,string IcuId);
        //public void UpdatePatient(Patient updatedpatient,Patient tobeupdated );
        IEnumerable<Patient> GetDetailsOfAllPatients();
        IEnumerable<Bed> GetAvailableBeds();
        IEnumerable<Bed> GetSpecificIcuAvailableBeds(string IcuId);
        public bool CheckIcuExists(string IcuId);
        public Patient GetPatientByIcuAndBed(string BedNo,string IcuId);

    }
}

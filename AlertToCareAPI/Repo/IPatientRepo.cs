using AlertToCareAPI.Models;
using System.Collections.Generic;

namespace AlertToCare.Data
{
    public interface IPatientRepo
    {
        bool SaveChanges();

        Patient GetPatientById(string id);
        public bool AddNewPatient(Patient patient);
        public void RemovePatient(Patient patient, string icuId);
        //public void UpdatePatient(Patient updatedpatient,Patient tobeupdated );
        IEnumerable<Patient> GetDetailsOfAllPatients();
        IEnumerable<Bed> GetAvailableBeds();
        IEnumerable<Bed> GetSpecificIcuAvailableBeds(string icuId);
        public bool CheckIcuExists(string icuId);
        public Patient GetPatientByIcuAndBed(string bedNo, string icuId);

    }
}

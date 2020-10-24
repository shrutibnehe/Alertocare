using System;
using System.Collections.Generic;
using System.Text;
using AlertToCare.Data;
using AlertToCareAPI.Models;
using AlertToCareAPI.Repo;

namespace AlertToCareAPITest.ControllerInterfaces
{
    class ISudoIcuOccupancyController : IPatientRepo
    {
        public void AddNewPatient(Patient patient)
        {
            patient.Id = "P02";
        }

        public IEnumerable<Patient> GetDetailsOfAllPatients()
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(string id)
        {
            throw new NotImplementedException();
        }

        public void RemovePatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}

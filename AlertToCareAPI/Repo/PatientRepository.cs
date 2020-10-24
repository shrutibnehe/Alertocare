using AlertToCare.Data;
using AlertToCareAPI.Database;
using AlertToCareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace AlertToCareAPI.Repo
{
    public class PatientRepository : IPatientRepo
    {
        private readonly DataContext _context;

        public PatientRepository(DataContext context)
        {
            _context = context;
        }

        public void AddNewPatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }
            //_context.BedsInfo.FromSqlRaw($"UPDATE BedsInfo SET IsOccupied = 1  WHERE BedNo = {patient.BedId} And IcuId={patient.IcuId}");
            //_context.PatientsInfo.Add(patient);
            //
            updateStatusofBeds(patient.BedId,patient.IcuId);
            _context.SaveChanges();


        }
        public void updateStatusofBeds(string BedId,string IcuId)
        {
            int status = 1;
            // _context.BedsInfo.FromSqlRaw($"UPDATE BedsInfo SET IsOccupied = {status}  WHERE BedNo = {BedId} And IcuId = {IcuId}");
            _context.BedsInfo.FromSqlRaw("UPDATE BedsInfo SET IsOccupied = 1");
            _context.SaveChanges();
        }

        public IEnumerable<Patient> GetDetailsOfAllPatients()
        {
            var _patients = _context.PatientsInfo.ToList();

            return _patients;
        }

        public Patient GetPatientById(string id)
        {
            return _context.PatientsInfo.Find(id);

        }


        public void RemovePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            //Make the bed occupied available then remove the patient
            _context.BedsInfo.FromSqlRaw($"UPDATE BedsInfo SET IsOccupied = 0 WHERE Id = {patient.Id}");
            _context.PatientsInfo.Remove(patient);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0); //To save changes into the database
        }

        [ExcludeFromCodeCoverage]
        public void UpdatePatient(Patient patient)
        {
            //Nothing to do here
        }
    }
}

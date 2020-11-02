using System;
using System.Collections.Generic;
using AlertToCare.Data;

using AlertToCareAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCareAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class IcuOccupancyController : ControllerBase
    {
        private readonly IPatientRepo _repository;

        public IcuOccupancyController(IPatientRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Patient> GetAllPatients()
        {
            var patients = _repository.GetDetailsOfAllPatients();
            return patients;
        }

        [HttpGet("{id}")]
        public ActionResult GetPatientById(string id)
        {
            var patient = _repository.GetPatientById(id);
            if (patient == null)
            {
                return BadRequest($"Patient with Id {id} Not present");
            }
            else
            {
                return Ok(patient);
            }

        }
        [HttpGet("AllAvailableBeds")]
        public ActionResult GetAvailableBeds()
        {
            var bedsList = _repository.GetAvailableBeds();
            if (bedsList != null)
            {
                return Ok(bedsList);
            }
            else
            {
                return BadRequest("No Available Beds");
            }

        }
        [HttpGet("IcuSpecific/{icuId}")]
        public ActionResult GetAvailableBedsForIcu(string icuId)
        {

            bool icuResponse = _repository.CheckIcuExists(icuId);
            if (icuResponse == false)
            {
                return BadRequest("Invalid Icu Id");
            }
            else
            {
                var availableBeds = _repository.GetSpecificIcuAvailableBeds(icuId);
                if (availableBeds != null)
                    return Ok(availableBeds);
                return BadRequest("Beds are not available");
            }
        }


        [HttpPost]
        public ActionResult AddNewPatient(Patient patient)
        {
            try
            {
                bool response = _repository.AddNewPatient(patient);
                if (response)
                {
                    _repository.SaveChanges();
                    return Ok();
                }
                return BadRequest("Invalid Bed and Icu Details Entered");
            }
            catch (Exception)
            {
                return BadRequest("Enter Valid PatientId");
            }


        }

        /* [HttpPut("{id}")]

         public ActionResult UpdatePatient(string id, Patient patient)
         {
             var PatientModelFromRepository = _repository.GetPatientById(id);
             if (PatientModelFromRepository == null)
             {
                 return NotFound();
             }
             else if(id!=patient.Id)
             {
                 return BadRequest("Enter Valid ID");
             }
            // _repository.UpdatePatient(patient,PatientModelFromRepository);
             PatientModelFromRepository.PatientName = patient.PatientName;
             PatientModelFromRepository.Age = patient.Age;
             PatientModelFromRepository.BedId = patient.BedId;
             PatientModelFromRepository.IcuId = patient.IcuId;
             PatientModelFromRepository.ContantNumber = patient.ContantNumber;

            // _repository.UpdatePatient(patient);
             _repository.SaveChanges();
             return Ok();
         }*/

        [HttpDelete("{id}/{icuId}")]

        public ActionResult RemovePatient(string id, string icuId)
        {
            var PatientModelFromRepository = _repository.GetPatientById(id);
            if (PatientModelFromRepository == null)
            {
                return NotFound();
            }
            _repository.RemovePatient(PatientModelFromRepository, icuId);
            _repository.SaveChanges();
            return Ok();
        }

        [HttpGet("Patient/{bedNo}/{icuId}")]
        public Patient GetPatientInfo(string bedNo, string icuId)
        {
            return _repository.GetPatientByIcuAndBed(bedNo, icuId);

        }


    }
}
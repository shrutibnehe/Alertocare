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
        public ActionResult<IEnumerable<Patient>> GetAllPatients()
        {
            var patients = _repository.GetDetailsOfAllPatients();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public ActionResult<Patient> GetPatientById(string id)
        {
            var patient = _repository.GetPatientById(id);
            if(patient==null)
            {
                return BadRequest($"Patient with Id {id} Not present");
            }
            else
            {
                return Ok(patient);
            }
            
        }
        [HttpGet("AllAvailableBeds")]
        public ActionResult<Bed> GetAvailableBeds()
        {
            var BedsList=_repository.GetAvailableBeds();
            if(BedsList!=null)
            {
                return Ok(BedsList);
            }
            else
            {
                return BadRequest("No Available Beds");
            }

        }
        [HttpGet("IcuSpecific/{IcuId}")]
        public ActionResult<Bed> GetAvailableBedsForIcu(string IcuId)
        {
           
            bool IcuResponse=_repository.CheckIcuExists(IcuId);
            if(IcuResponse==false)
            {
                return BadRequest("Invalid Icu Id");
            }
            else
            {
                var AvailableBeds=_repository.GetSpecificIcuAvailableBeds(IcuId);
                if(AvailableBeds!=null)
                    return Ok(AvailableBeds);
                return BadRequest("Beds are not available");
            }
        }


        [HttpPost]
        public ActionResult AddNewPatient(Patient patient)
        {
            try
            {
                bool response = _repository.AddNewPatient(patient);
                if (response == true)
                {
                    _repository.SaveChanges();
                    return Ok();
                }
                return BadRequest("Invalid Bed and Icu Details Entered");
            }catch(Exception exception)
            {
                return new ObjectResult(exception.Message);
            }
            
            
        }

        [HttpPut("{id}")]

        public ActionResult UpdatePatient(string id, Patient patient)
        {
            var PatientModelFromRepository = _repository.GetPatientById(id);
            if (PatientModelFromRepository == null)
            {
                return NotFound();
            }

            PatientModelFromRepository.PatientName = patient.PatientName;
            PatientModelFromRepository.Age = patient.Age;
            PatientModelFromRepository.BedId = patient.BedId;
            PatientModelFromRepository.IcuId = patient.IcuId;
            PatientModelFromRepository.ContantNumber = patient.ContantNumber;

            _repository.UpdatePatient(patient);
            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult RemovePatient(string id)
        {
            var PatientModelFromRepository = _repository.GetPatientById(id);
            if (PatientModelFromRepository == null)
            {
                return NotFound();
            }
            _repository.RemovePatient(PatientModelFromRepository);
            _repository.SaveChanges();
            return Ok();
        }

    }
}
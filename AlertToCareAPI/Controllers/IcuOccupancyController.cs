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

            return Ok(patient);
        }


        [HttpPost]
        public ActionResult AddNewPatient(Patient patient)
        {
            _repository.AddNewPatient(patient);
            _repository.SaveChanges();

            return NoContent();
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

            return NoContent();
        }

    }
}
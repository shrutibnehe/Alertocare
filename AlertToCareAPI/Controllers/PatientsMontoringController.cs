using System.Collections.Generic;
using AlertToCare.Data;
using AlertToCareAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCareAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PatientsMonitoringController : ControllerBase
    {
        private readonly IMonitoringRepo _repository;

        public PatientsMonitoringController(IMonitoringRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Vital>> GetVitals()
        {
            var vitals = _repository.GetAllVitals();

            return Ok(vitals);
        }

        [HttpGet("{id}")]
        public ActionResult<bool> CheckVitalsById(string id)
        {
            var vitalsModelFromRepo = _repository.GetVitalsById(id);
            if (vitalsModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.CheckVitals(vitalsModelFromRepo);

            return Ok();
        }
    }
}
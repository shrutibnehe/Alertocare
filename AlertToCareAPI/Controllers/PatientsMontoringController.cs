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

        [HttpGet("{icuID}")]
        public ActionResult<IEnumerable<Alert>> GetAlerts(string icuID)
        {
           var alerts = _repository.GetAllActiveAlerts(icuID);

            return Ok(alerts);
        }

        [HttpGet("{icuID}/{id}")]
        public ActionResult<bool> ChangeStatusOfAlert(string id)
        {
            var IsStatusChanged = _repository.AlertChangeStatus(id);
            return Ok(IsStatusChanged);
        }

        [HttpGet("sample")]
        public Alert Testing()
        {
            Alert alert = new Alert();
            alert.Id = "AL5";
            alert.Message = "testing";
            alert.PatientId = "hello";
            alert.IsActive = 1;
            alert.BedId = "B01";
            return alert;
        }
    }
}

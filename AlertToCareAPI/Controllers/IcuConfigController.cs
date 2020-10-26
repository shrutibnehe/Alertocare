using System.Collections.Generic;
using AlertToCare.Data;
using System.Data.SQLite;

using Microsoft.AspNetCore.Mvc;
using AlertToCareAPI.Utility;

namespace AlertToCareAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class IcuConfigController : ControllerBase
    {
        private readonly IIcuConfigurationRepository _repository;

        public IcuConfigController(IIcuConfigurationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Models.Icu> GetAllIcus()
        {
            var ICUs = _repository.GetAllIcus();

            return ICUs;
        }

        [HttpGet("{id}")]
        public ActionResult GetSpecificIcu(string id)
        {
            //return _repository.GetIcuById(id);
            Models.Icu icu = _repository.GetIcuById(id);
            if (icu == null)
            {
                return NotFound($"ICU with ID {id} is not Present");
            }
            return Ok(icu);
        }

        [HttpPost]
        public ActionResult AddIcu(Models.Icu icu)
        {
            /* if(!_repository.CheckLayoutId(icu.LayoutId))
             {
                 return new ObjectResult("Not Registered Layout");
             }*/
            Validations_Icu validations = new Validations_Icu();
            bool Response = validations.ValidateIcu(icu);
            if(Response==false)
            {
               return BadRequest("Please Enter Valid Details");
            }
            try
            {
                _repository.AddNewIcu(icu);
                _repository.SaveChanges();
                return Ok("Icu Added Successfully");
            }
            catch (SQLiteException exception)
            {
              return new ObjectResult(exception.Message);
            }
        }

        [HttpPut("{id}")]

        public ActionResult UpdateIcu(string id, Models.Icu icu)
        {
            var IcuModelFromRepository = _repository.GetIcuById(id);
            if(id!=icu.Id)
            {
                return BadRequest("Enter Valid Details");
            }
            if (IcuModelFromRepository == null)
            {
                return NotFound();
            }
            IcuModelFromRepository.BedCount = icu.BedCount;
            IcuModelFromRepository.LayoutId = icu.LayoutId;

            _repository.UpdateIcu(icu);
            _repository.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]

        public ActionResult DeleteIcu(string id)
        {
            var IcuModelFromRepository = _repository.GetIcuById(id);
            if (IcuModelFromRepository == null)
            {
                return NotFound();
            }
           
            _repository.RemoveIcu(IcuModelFromRepository);
            _repository.SaveChanges();

            return Ok(); 
        }
        [HttpGet("Layouts")]
        public ActionResult<IEnumerable<Models.Layout>> GetAllLayouts()
        {
            var Layouts = _repository.GetAllLayouts();

            return Ok(Layouts);
        }

        [HttpPost("{IcuId}/{BedCount}")]
        public ActionResult AddBeds(string IcuId,int BedCount)
        {
             bool response=_repository.ConfigureBeds(IcuId,BedCount);
            if(response==true)
            {
                _repository.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("Invalid IcuId and BedCount Entered");
            }
           
        }

    }
}
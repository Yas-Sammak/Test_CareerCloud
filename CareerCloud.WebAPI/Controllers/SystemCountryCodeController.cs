using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/system/v1")]
    public class SystemCountryCodeController : ControllerBase
    {

        private readonly SystemCountryCodeLogic _logic;
        public SystemCountryCodeController()
        {
            EFGenericRepository<SystemCountryCodePoco> repo = new EFGenericRepository<SystemCountryCodePoco>();
            _logic = new SystemCountryCodeLogic(repo);
        }

        [HttpGet]
        [Route("countrycode/{SystemCountryCode}")]
        [ProducesResponseType(typeof(SystemCountryCodePoco), 200)]
        public ActionResult GetSystemCountryCode([FromBody] string systemCountryCode)
        {
            var sysCode = _logic.GetByCode(systemCountryCode);
            if (sysCode == null)
            {
                return NotFound();
            }
            return Ok(sysCode);
        }

        [HttpPost]
        [Route("countrycode")]
        public ActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] SystemCountryCodes)
        {
            _logic.Add(SystemCountryCodes);
            return Ok();
        }

        [HttpPut]
        [Route("countrycode")]
        public ActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] SystemCountryCodes)
        {
            _logic.Update(SystemCountryCodes);
            return Ok();
        }

        [HttpDelete]
        [Route("countrycode")]
        public ActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] SystemCountryCodes)
        {
            _logic.Delete(SystemCountryCodes);
            return Ok();
        }

        [HttpGet]
        [Route("countrycode")]
        [ProducesResponseType(typeof(List<SystemCountryCodePoco>), 200)]
        public ActionResult GetAllSystemCountryCode()
        {
            var SystemCountryCodes = _logic.GetAll();
            if (SystemCountryCodes == null)
            {
                return NotFound();
            }
            return Ok(SystemCountryCodes);
        }

    }
}

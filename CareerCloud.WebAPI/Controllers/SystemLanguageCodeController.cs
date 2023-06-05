using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/system/v1")]
    public class SystemLanguageCodeController : ControllerBase
    {

        private readonly SystemLanguageCodeLogic _logic;
        public SystemLanguageCodeController()
        {
            EFGenericRepository<SystemLanguageCodePoco> repo = new EFGenericRepository<SystemLanguageCodePoco>();
            _logic = new SystemLanguageCodeLogic(repo);
        }

        [HttpGet]
        [Route("Languagecode/{SystemLanguageCode}")]
        [ProducesResponseType(typeof(SystemLanguageCodePoco), 200)]
        public ActionResult GetSystemLanguageCode([FromBody] string systemLanguageCode)
        {
            var sysCode = _logic.GetByLanguageId(systemLanguageCode);
            if (sysCode == null)
            {
                return NotFound();
            }
            return Ok(sysCode);
        }

        [HttpPost]
        [Route("Languagecode")]
        public ActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] SystemLanguageCodes)
        {
            _logic.Add(SystemLanguageCodes);
            return Ok();
        }

        [HttpPut]
        [Route("Languagecode")]
        public ActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] SystemLanguageCodes)
        {
            _logic.Update(SystemLanguageCodes);
            return Ok();
        }

        [HttpDelete]
        [Route("Languagecode")]
        public ActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] SystemLanguageCodes)
        {
            _logic.Delete(SystemLanguageCodes);
            return Ok();
        }

        [HttpGet]
        [Route("Languagecode")]
        [ProducesResponseType(typeof(List<SystemLanguageCodePoco>), 200)]
        public ActionResult GetAllSystemLanguageCode()
        {
            var SystemLanguageCodes = _logic.GetAll();
            if (SystemLanguageCodes == null)
            {
                return NotFound();
            }
            return Ok(SystemLanguageCodes);
        }



    }
}

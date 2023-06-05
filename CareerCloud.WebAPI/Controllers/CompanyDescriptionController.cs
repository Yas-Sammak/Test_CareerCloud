using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyDescriptionController : ControllerBase
    {
        private readonly CompanyDescriptionLogic _logic;

        public CompanyDescriptionController()
        {
            EFGenericRepository<CompanyDescriptionPoco> repo = new EFGenericRepository<CompanyDescriptionPoco>();
            _logic = new CompanyDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("description/{CompanyDescriptionId}")]
        [ProducesResponseType(typeof(CompanyDescriptionPoco), 200)]
        public ActionResult GetCompanyDescription(Guid CompanyDescriptionId)
        {
            var CompanyDescription = _logic.Get(CompanyDescriptionId);
            if (CompanyDescription == null)
            {
                return NotFound();
            }
            return Ok(CompanyDescription);
        }

        [HttpPost]
        [Route("description")]
        public ActionResult PostCompanyDescription([FromBody] CompanyDescriptionPoco[] CompanyDescriptions)
        {
            _logic.Add(CompanyDescriptions);
            return Ok();
        }

        [HttpPut]
        [Route("description")]
        public ActionResult PutCompanyDescription([FromBody] CompanyDescriptionPoco[] CompanyDescriptions)
        {
            _logic.Update(CompanyDescriptions);
            return Ok();
        }

        [HttpDelete]
        [Route("description")]
        public ActionResult DeleteCompanyDescription([FromBody] CompanyDescriptionPoco[] CompanyDescriptions)
        {
            _logic.Delete(CompanyDescriptions);
            return Ok();
        }

        [HttpGet]
        [Route("description")]
        [ProducesResponseType(typeof(List<CompanyDescriptionPoco>), 200)]
        public ActionResult GetAllCompanyDescription()
        {
            var CompanyDescriptions = _logic.GetAll();
            return Ok(CompanyDescriptions);
        }


    }
}

using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyJobEducationController : ControllerBase
    {

        private readonly CompanyJobEducationLogic _logic;

        public CompanyJobEducationController()
        {
            EFGenericRepository<CompanyJobEducationPoco> repo = new EFGenericRepository<CompanyJobEducationPoco>();
            _logic = new CompanyJobEducationLogic(repo);
        }

        [HttpGet]
        [Route("JobEducation/{CompanyJobEducationId}")]
        [ProducesResponseType(typeof(CompanyJobEducationPoco), 200)]
        public ActionResult GetCompanyJobEducation(Guid CompanyJobEducationId)
        {
            var CompanyJobEducation = _logic.Get(CompanyJobEducationId);
            if (CompanyJobEducation == null)
            {
                return NotFound();
            }
            return Ok(CompanyJobEducation);
        }

        [HttpPost]
        [Route("JobEducation")]
        public ActionResult PostCompanyJobEducation([FromBody] CompanyJobEducationPoco[] CompanyJobEducations)
        {
            _logic.Add(CompanyJobEducations);
            return Ok();
        }

        [HttpPut]
        [Route("JobEducation")]
        public ActionResult PutCompanyJobEducation([FromBody] CompanyJobEducationPoco[] CompanyJobEducations)
        {
            _logic.Update(CompanyJobEducations);
            return Ok();
        }

        [HttpDelete]
        [Route("JobEducation")]
        public ActionResult DeleteCompanyJobEducation([FromBody] CompanyJobEducationPoco[] CompanyJobEducations)
        {
            _logic.Delete(CompanyJobEducations);
            return Ok();
        }

        [HttpGet]
        [Route("JobEducation")]
        [ProducesResponseType(typeof(List<CompanyJobEducationPoco>), 200)]
        public ActionResult GetAllCompanyJobEducation()
        {
            var CompanyJobEducations = _logic.GetAll();
            return Ok(CompanyJobEducations);
        }


    }
}

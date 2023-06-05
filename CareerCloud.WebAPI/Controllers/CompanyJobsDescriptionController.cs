using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyJobsDescriptionController : ControllerBase
    {
        private readonly CompanyJobDescriptionLogic _logic;

        public CompanyJobsDescriptionController()
        {
            EFGenericRepository<CompanyJobDescriptionPoco> repo = new EFGenericRepository<CompanyJobDescriptionPoco>();
            _logic = new CompanyJobDescriptionLogic(repo);
        }

        [HttpGet]
        [Route("JobDescription/{CompanyJobDescriptionId}")]
        [ProducesResponseType(typeof(CompanyJobDescriptionPoco), 200)]
        public ActionResult GetCompanyJobsDescription(Guid CompanyJobDescriptionId)
        {
            var CompanyJobDescription = _logic.Get(CompanyJobDescriptionId);
            if (CompanyJobDescription == null)
            {
                return NotFound();
            }
            return Ok(CompanyJobDescription);
        }

        [HttpPost]
        [Route("JobDescription")]
        public ActionResult PostCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] CompanyJobDescriptions)
        {
            _logic.Add(CompanyJobDescriptions);
            return Ok();
        }

        [HttpPut]
        [Route("JobDescription")]
        public ActionResult PutCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] CompanyJobDescriptions)
        {
            _logic.Update(CompanyJobDescriptions);
            return Ok();
        }

        [HttpDelete]
        [Route("JobDescription")]
        public ActionResult DeleteCompanyJobsDescription([FromBody] CompanyJobDescriptionPoco[] CompanyJobDescriptions)
        {
            _logic.Delete(CompanyJobDescriptions);
            return Ok();
        }

        [HttpGet]
        [Route("JobDescription")]
        [ProducesResponseType(typeof(List<CompanyJobDescriptionPoco>), 200)]
        public ActionResult GetAllCompanyJobsDescription()
        {
            var CompanyJobDescriptions = _logic.GetAll();
            return Ok(CompanyJobDescriptions);
        }

    }
}

using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyJobController : ControllerBase
    {
        private readonly CompanyJobLogic _logic;

        public CompanyJobController()
        {
            EFGenericRepository<CompanyJobPoco> repo = new EFGenericRepository<CompanyJobPoco>();
            _logic = new CompanyJobLogic(repo);
        }

        [HttpGet]
        [Route("Job/{CompanyJobId}")]
        [ProducesResponseType(typeof(CompanyJobPoco), 200)]
        public ActionResult GetCompanyJob(Guid CompanyJobId)
        {
            var CompanyJob = _logic.Get(CompanyJobId);
            if (CompanyJob == null)
            {
                return NotFound();
            }
            return Ok(CompanyJob);
        }

        [HttpPost]
        [Route("Job")]
        public ActionResult PostCompanyJob([FromBody] CompanyJobPoco[] CompanyJobs)
        {
            _logic.Add(CompanyJobs);
            return Ok();
        }

        [HttpPut]
        [Route("Job")]
        public ActionResult PutCompanyJob([FromBody] CompanyJobPoco[] CompanyJobs)
        {
            _logic.Update(CompanyJobs);
            return Ok();
        }

        [HttpDelete]
        [Route("Job")]
        public ActionResult DeleteCompanyJob([FromBody] CompanyJobPoco[] CompanyJobs)
        {
            _logic.Delete(CompanyJobs);
            return Ok();
        }

        [HttpGet]
        [Route("Job")]
        [ProducesResponseType(typeof(List<CompanyJobPoco>), 200)]
        public ActionResult GetAllCompanyJob()
        {
            var CompanyJobs = _logic.GetAll();
            return Ok(CompanyJobs);
        }

    }
}

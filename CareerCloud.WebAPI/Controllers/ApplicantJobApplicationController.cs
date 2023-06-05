using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    public class ApplicantJobApplicationController : ControllerBase
    {
        private readonly ApplicantJobApplicationLogic _logic;

        public ApplicantJobApplicationController()
        {
            EFGenericRepository<ApplicantJobApplicationPoco> repo = new EFGenericRepository<ApplicantJobApplicationPoco>();
            _logic = new ApplicantJobApplicationLogic(repo);
        }

        [HttpGet]
        [Route("jobApplication/{applicantJobApplicationId}")]
        [ProducesResponseType(typeof(ApplicantJobApplicationPoco), 200)]
        public ActionResult GetApplicantJobApplication(Guid applicantJobApplicationId)
        {
            var applicantJobApplication = _logic.Get(applicantJobApplicationId);
            if (applicantJobApplication == null)
            {
                return NotFound();
            }
            return Ok(applicantJobApplication);
        }

        [HttpPost]
        [Route("jobApplication")]
        public ActionResult PostApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] applicantJobApplications)
        {
            _logic.Add(applicantJobApplications);
            return Ok();
        }

        [HttpPut]
        [Route("jobApplication")]
        public ActionResult PutApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] applicantJobApplications)
        {
            _logic.Update(applicantJobApplications);
            return Ok();
        }

        [HttpDelete]
        [Route("jobApplication")]
        public ActionResult DeleteApplicantJobApplication([FromBody] ApplicantJobApplicationPoco[] applicantJobApplications)
        {
            _logic.Delete(applicantJobApplications);
            return Ok();
        }

        [HttpGet]
        [Route("jobApplication")]
        [ProducesResponseType(typeof(List<ApplicantJobApplicationPoco>), 200)]
        public ActionResult GetAllApplicantJobApplication()
        {
            var applicantJobApplications = _logic.GetAll();
            return Ok(applicantJobApplications);
        }

    }
}

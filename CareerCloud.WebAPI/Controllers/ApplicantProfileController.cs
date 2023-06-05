using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    public class ApplicantProfileController : ControllerBase
    {

        private readonly ApplicantProfileLogic _logic;

        public ApplicantProfileController()
        {
            EFGenericRepository<ApplicantProfilePoco> repo = new EFGenericRepository<ApplicantProfilePoco>();
            _logic = new ApplicantProfileLogic(repo);
        }

        [HttpGet]
        [Route("Profile/{applicantProfileId}")]
        [ProducesResponseType(typeof(ApplicantProfilePoco), 200)]
        public ActionResult GetApplicantProfile(Guid applicantProfileId)
        {
            var applicantProfile = _logic.Get(applicantProfileId);
            if (applicantProfile == null)
            {
                return NotFound();
            }
            return Ok(applicantProfile);
        }

        [HttpPost]
        [Route("Profile")]
        public ActionResult PostApplicantProfile([FromBody] ApplicantProfilePoco[] applicantProfiles)
        {
            _logic.Add(applicantProfiles);
            return Ok();
        }

        [HttpPut]
        [Route("Profile")]
        public ActionResult PutApplicantProfile([FromBody] ApplicantProfilePoco[] applicantProfiles)
        {
            _logic.Update(applicantProfiles);
            return Ok();
        }

        [HttpDelete]
        [Route("Profile")]
        public ActionResult DeleteApplicantProfile([FromBody] ApplicantProfilePoco[] applicantProfiles)
        {
            _logic.Delete(applicantProfiles);
            return Ok();
        }

        [HttpGet]
        [Route("Profile")]
        [ProducesResponseType(typeof(List<ApplicantProfilePoco>), 200)]
        public ActionResult GetAllApplicantProfile()
        {
            var applicantProfiles = _logic.GetAll();
            return Ok(applicantProfiles);
        }



    }
}

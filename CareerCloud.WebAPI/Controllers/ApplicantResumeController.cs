using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    public class ApplicantResumeController : ControllerBase
    {
        private readonly ApplicantResumeLogic _logic;

        public ApplicantResumeController()
        {
            EFGenericRepository<ApplicantResumePoco> repo = new EFGenericRepository<ApplicantResumePoco>();
            _logic = new ApplicantResumeLogic(repo);
        }

        [HttpGet]
        [Route("Resume/{applicantResumeId}")]
        [ProducesResponseType(typeof(ApplicantResumePoco), 200)]
        public ActionResult GetApplicantResume(Guid applicantResumeId)
        {
            var applicantResume = _logic.Get(applicantResumeId);
            if (applicantResume == null)
            {
                return NotFound();
            }
            return Ok(applicantResume);
        }

        [HttpPost]
        [Route("Resume")]
        public ActionResult PostApplicantResume([FromBody] ApplicantResumePoco[] applicantResumes)
        {
            _logic.Add(applicantResumes);
            return Ok();
        }

        [HttpPut]
        [Route("Resume")]
        public ActionResult PutApplicantResume([FromBody] ApplicantResumePoco[] applicantResumes)
        {
            _logic.Update(applicantResumes);
            return Ok();
        }

        [HttpDelete]
        [Route("Resume")]
        public ActionResult DeleteApplicantResume([FromBody] ApplicantResumePoco[] applicantResumes)
        {
            _logic.Delete(applicantResumes);
            return Ok();
        }

        [HttpGet]
        [Route("Resume")]
        [ProducesResponseType(typeof(List<ApplicantResumePoco>), 200)]
        public ActionResult GetAllApplicantResume()
        {
            var applicantResumes = _logic.GetAll();
            return Ok(applicantResumes);
        }




    }
}

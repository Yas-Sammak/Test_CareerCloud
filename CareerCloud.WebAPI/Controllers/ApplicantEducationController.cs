using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CareerCloud.Pocos;
using CareerCloud.DataAccessLayer;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;


namespace CareerCloud.WebAPI.Controllers
{
    
    [Route("api/careercloud/applicant/v1")]
    public class ApplicantEducationController : ControllerBase
    {

        private readonly ApplicantEducationLogic _logic;

        public ApplicantEducationController()
        {
            EFGenericRepository<ApplicantEducationPoco> repo = new EFGenericRepository<ApplicantEducationPoco>();
            _logic = new ApplicantEducationLogic(repo);
        }

        [HttpGet]
        [Route("education/{applicantEducationId}")]
        [ProducesResponseType(typeof(ApplicantEducationPoco), 200)]
        public ActionResult GetApplicantEducation(Guid applicantEducationId)
        {
            var applicantEducation = _logic.Get(applicantEducationId);
            if (applicantEducation == null)
            {
                return NotFound();
            }
            return Ok(applicantEducation);
        }

        [HttpPost]
        [Route("education")]
        public ActionResult PostApplicantEducation([FromBody] ApplicantEducationPoco[] applicantEducations)
        {
            _logic.Add(applicantEducations);
            return Ok();
        }

        [HttpPut]
        [Route("education")]
        public ActionResult PutApplicantEducation([FromBody] ApplicantEducationPoco[] applicantEducations)
        {
            _logic.Update(applicantEducations);
            return Ok();
        }

        [HttpDelete]
        [Route("education")]
        public ActionResult DeleteApplicantEducation([FromBody] ApplicantEducationPoco[] applicantEducations)
        {
            _logic.Delete(applicantEducations);
            return Ok();
        }

        [HttpGet]
        [Route("education")]
        [ProducesResponseType(typeof(List<ApplicantEducationPoco>), 200)]
        public ActionResult GetAllApplicantEducation()
        {
            var applicantEducations = _logic.GetAll();
            return Ok(applicantEducations);
        }


        
    }
}

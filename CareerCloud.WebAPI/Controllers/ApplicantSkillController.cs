using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    public class ApplicantSkillController : ControllerBase
    {
        private readonly ApplicantSkillLogic _logic;

        public ApplicantSkillController()
        {
            EFGenericRepository<ApplicantSkillPoco> repo = new EFGenericRepository<ApplicantSkillPoco>();
            _logic = new ApplicantSkillLogic(repo);
        }

        [HttpGet]
        [Route("Skill/{applicantSkillId}")]
        [ProducesResponseType(typeof(ApplicantSkillPoco), 200)]
        public ActionResult GetApplicantSkill(Guid applicantSkillId)
        {
            var applicantSkill = _logic.Get(applicantSkillId);
            if (applicantSkill == null)
            {
                return NotFound();
            }
            return Ok(applicantSkill);
        }

        [HttpPost]
        [Route("Skill")]
        public ActionResult PostApplicantSkill([FromBody] ApplicantSkillPoco[] applicantSkills)
        {
            _logic.Add(applicantSkills);
            return Ok();
        }

        [HttpPut]
        [Route("Skill")]
        public ActionResult PutApplicantSkill([FromBody] ApplicantSkillPoco[] applicantSkills)
        {
            _logic.Update(applicantSkills);
            return Ok();
        }

        [HttpDelete]
        [Route("Skill")]
        public ActionResult DeleteApplicantSkill([FromBody] ApplicantSkillPoco[] applicantSkills)
        {
            _logic.Delete(applicantSkills);
            return Ok();
        }

        [HttpGet]
        [Route("Skill")]
        [ProducesResponseType(typeof(List<ApplicantSkillPoco>), 200)]
        public ActionResult GetAllApplicantSkill()
        {
            var applicantSkills = _logic.GetAll();
            return Ok(applicantSkills);
        }



    }
}

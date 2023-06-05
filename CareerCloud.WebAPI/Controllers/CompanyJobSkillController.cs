using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyJobSkillController : ControllerBase
    {
        private readonly CompanyJobSkillLogic _logic;

        public CompanyJobSkillController()
        {
            EFGenericRepository<CompanyJobSkillPoco> repo = new EFGenericRepository<CompanyJobSkillPoco>();
            _logic = new CompanyJobSkillLogic(repo);
        }

        [HttpGet]
        [Route("JobSkill/{CompanyJobSkillId}")]
        [ProducesResponseType(typeof(CompanyJobSkillPoco), 200)]
        public ActionResult GetCompanyJobSkill(Guid CompanyJobSkillId)
        {
            var CompanyJobSkill = _logic.Get(CompanyJobSkillId);
            if (CompanyJobSkill == null)
            {
                return NotFound();
            }
            return Ok(CompanyJobSkill);
        }

        [HttpPost]
        [Route("JobSkill")]
        public ActionResult PostCompanyJobSkill([FromBody] CompanyJobSkillPoco[] CompanyJobSkills)
        {
            _logic.Add(CompanyJobSkills);
            return Ok();
        }

        [HttpPut]
        [Route("JobSkill")]
        public ActionResult PutCompanyJobSkill([FromBody] CompanyJobSkillPoco[] CompanyJobSkills)
        {
            _logic.Update(CompanyJobSkills);
            return Ok();
        }

        [HttpDelete]
        [Route("JobSkill")]
        public ActionResult DeleteCompanyJobSkill([FromBody] CompanyJobSkillPoco[] CompanyJobSkills)
        {
            _logic.Delete(CompanyJobSkills);
            return Ok();
        }

        [HttpGet]
        [Route("JobSkill")]
        [ProducesResponseType(typeof(List<CompanyJobSkillPoco>), 200)]
        public ActionResult GetAllCompanyJobSkill()
        {
            var CompanyJobSkills = _logic.GetAll();
            return Ok(CompanyJobSkills);
        }


    }
}

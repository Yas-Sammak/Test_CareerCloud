using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyProfileController : ControllerBase
    {

        private readonly CompanyProfileLogic _logic;

        public CompanyProfileController()
        {
            EFGenericRepository<CompanyProfilePoco> repo = new EFGenericRepository<CompanyProfilePoco>();
            _logic = new CompanyProfileLogic(repo);
        }

        [HttpGet]
        [Route("Profile/{CompanyProfileId}")]
        [ProducesResponseType(typeof(CompanyProfilePoco), 200)]
        public ActionResult GetCompanyProfile(Guid CompanyProfileId)
        {
            var CompanyProfile = _logic.Get(CompanyProfileId);
            if (CompanyProfile == null)
            {
                return NotFound();
            }
            return Ok(CompanyProfile);
        }

        [HttpPost]
        [Route("Profile")]
        public ActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] CompanyProfiles)
        {
            _logic.Add(CompanyProfiles);
            return Ok();
        }

        [HttpPut]
        [Route("Profile")]
        public ActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] CompanyProfiles)
        {
            _logic.Update(CompanyProfiles);
            return Ok();
        }

        [HttpDelete]
        [Route("Profile")]
        public ActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] CompanyProfiles)
        {
            _logic.Delete(CompanyProfiles);
            return Ok();
        }

        [HttpGet]
        [Route("Profile")]
        [ProducesResponseType(typeof(List<CompanyProfilePoco>), 200)]
        public ActionResult GetAllCompanyProfile()
        {
            var CompanyProfiles = _logic.GetAll();
            return Ok(CompanyProfiles);
        }


    }
}

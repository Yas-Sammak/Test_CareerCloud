using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/company/v1")]
    public class CompanyLocationController : ControllerBase
    {
        private readonly CompanyLocationLogic _logic;

        public CompanyLocationController()
        {
            EFGenericRepository<CompanyLocationPoco> repo = new EFGenericRepository<CompanyLocationPoco>();
            _logic = new CompanyLocationLogic(repo);
        }

        [HttpGet]
        [Route("Location/{CompanyLocationId}")]
        [ProducesResponseType(typeof(CompanyLocationPoco), 200)]
        public ActionResult GetCompanyLocation(Guid CompanyLocationId)
        {
            var CompanyLocation = _logic.Get(CompanyLocationId);
            if (CompanyLocation == null)
            {
                return NotFound();
            }
            return Ok(CompanyLocation);
        }

        [HttpPost]
        [Route("Location")]
        public ActionResult PostCompanyLocation([FromBody] CompanyLocationPoco[] CompanyLocations)
        {
            _logic.Add(CompanyLocations);
            return Ok();
        }

        [HttpPut]
        [Route("Location")]
        public ActionResult PutCompanyLocation([FromBody] CompanyLocationPoco[] CompanyLocations)
        {
            _logic.Update(CompanyLocations);
            return Ok();
        }

        [HttpDelete]
        [Route("Location")]
        public ActionResult DeleteCompanyLocation([FromBody] CompanyLocationPoco[] CompanyLocations)
        {
            _logic.Delete(CompanyLocations);
            return Ok();
        }

        [HttpGet]
        [Route("Location")]
        [ProducesResponseType(typeof(List<CompanyLocationPoco>), 200)]
        public ActionResult GetAllCompanyLocation()
        {
            var CompanyLocations = _logic.GetAll();
            return Ok(CompanyLocations);
        }

    }
}

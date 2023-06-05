using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/security/v1")]
    public class SecurityLoginController : ControllerBase
    {

        private readonly SecurityLoginLogic _logic;

        public SecurityLoginController()
        {
            EFGenericRepository<SecurityLoginPoco> repo = new EFGenericRepository<SecurityLoginPoco>();
            _logic = new SecurityLoginLogic(repo);
        }

        [HttpGet]
        [Route("login/{SecurityLoginId}")]
        [ProducesResponseType(typeof(SecurityLoginPoco), 200)]
        public ActionResult GetSecurityLogin(Guid SecurityLoginId)
        {
            var SecurityLogin = _logic.Get(SecurityLoginId);
            if (SecurityLogin == null)
            {
                return NotFound();
            }
            return Ok(SecurityLogin);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] SecurityLogins)
        {
            _logic.Add(SecurityLogins);
            return Ok();
        }

        [HttpPut]
        [Route("login")]
        public ActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] SecurityLogins)
        {
            _logic.Update(SecurityLogins);
            return Ok();
        }

        [HttpDelete]
        [Route("login")]
        public ActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] SecurityLogins)
        {
            _logic.Delete(SecurityLogins);
            return Ok();
        }

        [HttpGet]
        [Route("login")]
        [ProducesResponseType(typeof(List<SecurityLoginPoco>), 200)]
        public ActionResult GetAllSecurityLogin()
        {
            var SecurityLogins = _logic.GetAll();
            return Ok(SecurityLogins);
        }

    }
}

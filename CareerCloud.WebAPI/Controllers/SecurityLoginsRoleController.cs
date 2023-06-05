using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/security/v1")]
    public class SecurityLoginsRoleController : ControllerBase
    {

        private readonly SecurityLoginsRoleLogic _logic;

        public SecurityLoginsRoleController()
        {
            EFGenericRepository<SecurityLoginsRolePoco> repo = new EFGenericRepository<SecurityLoginsRolePoco>();
            _logic = new SecurityLoginsRoleLogic(repo);
        }

        [HttpGet]
        [Route("LoginsRole/{SecurityLoginsRoleId}")]
        [ProducesResponseType(typeof(SecurityLoginsRolePoco), 200)]
        public ActionResult GetSecurityLoginsRole(Guid SecurityLoginsRoleId)
        {
            var SecurityLoginsRole = _logic.Get(SecurityLoginsRoleId);
            if (SecurityLoginsRole == null)
            {
                return NotFound();
            }
            return Ok(SecurityLoginsRole);
        }

        [HttpPost]
        [Route("LoginsRole")]
        public ActionResult PostSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] SecurityLoginsRoles)
        {
            _logic.Add(SecurityLoginsRoles);
            return Ok();
        }

        [HttpPut]
        [Route("LoginsRole")]
        public ActionResult PutSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] SecurityLoginsRoles)
        {
            _logic.Update(SecurityLoginsRoles);
            return Ok();
        }

        [HttpDelete]
        [Route("LoginsRole")]
        public ActionResult DeleteSecurityLoginRole([FromBody] SecurityLoginsRolePoco[] SecurityLoginsRoles)
        {
            _logic.Delete(SecurityLoginsRoles);
            return Ok();
        }

        [HttpGet]
        [Route("LoginsRole")]
        [ProducesResponseType(typeof(List<SecurityLoginsRolePoco>), 200)]
        public ActionResult GetAllSecurityLoginRole()
        {
            var SecurityLoginsRoles = _logic.GetAll();
            return Ok(SecurityLoginsRoles);
        }

    }
}

using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/security/v1")]
    public class SecurityRoleController : ControllerBase
    {
        private readonly SecurityRoleLogic _logic;
        public SecurityRoleController()
        {
            EFGenericRepository<SecurityRolePoco> repo = new EFGenericRepository<SecurityRolePoco>();
            _logic = new SecurityRoleLogic(repo);
        }

        [HttpGet]
        [Route("Role/{SecurityRoleId}")]
        [ProducesResponseType(typeof(SecurityRolePoco), 200)]
        public ActionResult GetSecurityRole(Guid SecurityRoleId)
        {
            var SecurityRole = _logic.Get(SecurityRoleId);
            if (SecurityRole == null)
            {
                return NotFound();
            }
            return Ok(SecurityRole);
        }

        [HttpPost]
        [Route("Role")]
        public ActionResult PostSecurityRole([FromBody] SecurityRolePoco[] SecurityRoles)
        {
            _logic.Add(SecurityRoles);
            return Ok();
        }

        [HttpPut]
        [Route("Role")]
        public ActionResult PutSecurityRole([FromBody] SecurityRolePoco[] SecurityRoles)
        {
            _logic.Update(SecurityRoles);
            return Ok();
        }

        [HttpDelete]
        [Route("Role")]
        public ActionResult DeleteSecurityRole([FromBody] SecurityRolePoco[] SecurityRoles)
        {
            _logic.Delete(SecurityRoles);
            return Ok();
        }

        [HttpGet]
        [Route("Role")]
        [ProducesResponseType(typeof(List<SecurityRolePoco>), 200)]
        public ActionResult GetAllSecurityRole()
        {
            var SecurityRoles = _logic.GetAll();
            return Ok(SecurityRoles);
        }



    }
}

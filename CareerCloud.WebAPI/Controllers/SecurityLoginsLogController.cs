using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/security/v1")]
    public class SecurityLoginsLogController : ControllerBase
    {

        private readonly SecurityLoginsLogLogic _logic;

        public SecurityLoginsLogController()
        {
            EFGenericRepository<SecurityLoginsLogPoco> repo = new EFGenericRepository<SecurityLoginsLogPoco>();
            _logic = new SecurityLoginsLogLogic(repo);
        }

        [HttpGet]
        [Route("loginslog/{SecurityLoginsLogId}")]
        [ProducesResponseType(typeof(SecurityLoginsLogPoco), 200)]
        public ActionResult GetSecurityLoginLog(Guid SecurityLoginsLogId)
        {
            var SecurityLoginsLog = _logic.Get(SecurityLoginsLogId);
            if (SecurityLoginsLog == null)
            {
                return NotFound();
            }
            return Ok(SecurityLoginsLog);
        }

        [HttpPost]
        [Route("loginslog")]
        public ActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] SecurityLoginsLogs)
        {
            _logic.Add(SecurityLoginsLogs);
            return Ok();
        }

        [HttpPut]
        [Route("loginslog")]
        public ActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] SecurityLoginsLogs)
        {
            _logic.Update(SecurityLoginsLogs);
            return Ok();
        }

        [HttpDelete]
        [Route("loginslog")]
        public ActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] SecurityLoginsLogs)
        {
            _logic.Delete(SecurityLoginsLogs);
            return Ok();
        }

        [HttpGet]
        [Route("loginslog")]
        [ProducesResponseType(typeof(List<SecurityLoginsLogPoco>), 200)]
        public ActionResult GetAllSecurityLoginLog()
        {
            var SecurityLoginsLogs = _logic.GetAll();
            return Ok(SecurityLoginsLogs);
        }

    }
}

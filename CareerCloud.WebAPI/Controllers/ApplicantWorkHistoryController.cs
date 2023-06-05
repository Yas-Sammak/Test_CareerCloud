using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using Microsoft.AspNetCore.Mvc;

namespace CareerCloud.WebAPI.Controllers
{
    [Route("api/careercloud/applicant/v1")]
    public class ApplicantWorkHistoryController : ControllerBase
    {
        private readonly ApplicantWorkHistoryLogic _logic;

        public ApplicantWorkHistoryController()
        {
            EFGenericRepository<ApplicantWorkHistoryPoco> repo = new EFGenericRepository<ApplicantWorkHistoryPoco>();
            _logic = new ApplicantWorkHistoryLogic(repo);
        }

        [HttpGet]
        [Route("WorkHistory/{applicantWorkHistoryId}")]
        [ProducesResponseType(typeof(ApplicantWorkHistoryPoco), 200)]
        public ActionResult GetApplicantWorkHistory(Guid applicantWorkHistoryId)
        {
            var applicantWorkHistory = _logic.Get(applicantWorkHistoryId);
            if (applicantWorkHistory == null)
            {
                return NotFound();
            }
            return Ok(applicantWorkHistory);
        }

        [HttpPost]
        [Route("WorkHistory")]
        public ActionResult PostApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] applicantWorkHistorys)
        {
            _logic.Add(applicantWorkHistorys);
            return Ok();
        }

        [HttpPut]
        [Route("WorkHistory")]
        public ActionResult PutApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] applicantWorkHistorys)
        {
            _logic.Update(applicantWorkHistorys);
            return Ok();
        }

        [HttpDelete]
        [Route("WorkHistory")]
        public ActionResult DeleteApplicantWorkHistory([FromBody] ApplicantWorkHistoryPoco[] applicantWorkHistorys)
        {
            _logic.Delete(applicantWorkHistorys);
            return Ok();
        }

        [HttpGet]
        [Route("WorkHistory")]
        [ProducesResponseType(typeof(List<ApplicantWorkHistoryPoco>), 200)]
        public ActionResult GetAllApplicantWorkHistory()
        {
            var applicantWorkHistorys = _logic.GetAll();
            return Ok(applicantWorkHistorys);
        }



    }
}

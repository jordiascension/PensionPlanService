using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PensionPlan.Application.Services;

namespace PensionPlan.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionPlanController : ControllerBase
    {

        private readonly ILogger<PensionPlanController> _logger;
        private readonly IPensionPlanService _pensionPlan;


        public PensionPlanController(ILogger<PensionPlanController> logger, IPensionPlanService pensionPlan) {
            _logger = logger;
            _pensionPlan = pensionPlan;

        }

        [HttpGet("CalculateTaxDeduction")]
        public int CalculateTaxDeduction(int naturalPersonPensionPlan, int selfEmployedPensionPlan,
            int companyPensionPlan, int taxBase)
        {
            _logger.LogInformation("Starting method Add");
            _logger.LogDebug("num1: " + naturalPersonPensionPlan);
            _logger.LogDebug("num2: " + companyPensionPlan);
            _logger.LogDebug("num3: " + selfEmployedPensionPlan);
            _logger.LogDebug("num4: " + taxBase);

            var taxDeduction = _pensionPlan.CalculateTaxDeduction(naturalPersonPensionPlan, selfEmployedPensionPlan,
                companyPensionPlan, taxBase);
            _logger.LogInformation("Dedución = " + taxDeduction);
            _logger.LogInformation("Finish method Add");
            return taxDeduction;
        }
    }
}

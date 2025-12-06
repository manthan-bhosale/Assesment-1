using Microsoft.AspNetCore.Mvc;

namespace AvalphaTechnologies.CommissionCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommisionController : ControllerBase
    {
        [ProducesResponseType(typeof(CommissionCalculationResponse), 200)]
        [HttpPost]
        public IActionResult Calculate(CommissionCalculationRequest calculationRequest)
        {
            // Input Validations
            if (calculationRequest.LocalSalesCount < 0 || calculationRequest.LocalSalesCount > 1_000_000 ||
                calculationRequest.ForeignSalesCount < 0 || calculationRequest.ForeignSalesCount > 1_000_000 ||
                calculationRequest.AverageSaleAmount < 0 || calculationRequest.AverageSaleAmount > 1_000_000)
            {
                return BadRequest(new
                {
                    message = "All input values must be between 0 and 1,000,000."
                });
            }

            // Commission Rates
            decimal avalphaLocalRate = 0.20m;     
            decimal avalphaForeignRate = 0.35m;   

            decimal competitorLocalRate = 0.02m;   
            decimal competitorForeignRate = 0.0755m;

            // Avalpha Calculation
            decimal avalphaLocalCommission = calculationRequest.LocalSalesCount * calculationRequest.AverageSaleAmount * avalphaLocalRate;

            decimal avalphaForeignCommission = calculationRequest.ForeignSalesCount * calculationRequest.AverageSaleAmount * avalphaForeignRate;

            decimal totalAvalphaCommission = avalphaLocalCommission + avalphaForeignCommission;

            // Competitor Calculation
            decimal competitorLocalCommission = calculationRequest.LocalSalesCount * calculationRequest.AverageSaleAmount * competitorLocalRate;

            decimal competitorForeignCommission = calculationRequest.ForeignSalesCount * calculationRequest.AverageSaleAmount * competitorForeignRate;

            decimal totalCompetitorCommission = competitorLocalCommission + competitorForeignCommission;

            return Ok(new CommissionCalculationResponse() {
                AvalphaTechnologiesCommissionAmount = decimal.Round(totalAvalphaCommission, 2),
                CompetitorCommissionAmount = decimal.Round(totalCompetitorCommission, 2)
            });
        }
    }

    public class CommissionCalculationRequest
    {
        public int LocalSalesCount { get; set; }
        public int ForeignSalesCount { get; set; }
        public decimal AverageSaleAmount { get; set; }
    }

    public class CommissionCalculationResponse
    {
        public decimal AvalphaTechnologiesCommissionAmount { get; set; }

        public decimal CompetitorCommissionAmount { get; set; }
    }
}

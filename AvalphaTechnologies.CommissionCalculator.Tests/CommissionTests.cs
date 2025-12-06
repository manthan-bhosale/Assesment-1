using AvalphaTechnologies.CommissionCalculator.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AvalphaTechnologies.CommissionCalculator.Tests
{
    public class CommissionTests
    {
        [Fact]
        public void Calculate_ReturnsCorrectCommission()
        {
            var controller = new CommisionController();

            var request = new CommissionCalculationRequest
            {
                LocalSalesCount = 10,
                ForeignSalesCount = 5,
                AverageSaleAmount = 100
            };

            var result = controller.Calculate(request) as OkObjectResult;
            var data = result.Value as CommissionCalculationResponse;

            Assert.Equal(375, data.AvalphaTechnologiesCommissionAmount);
            Assert.Equal(57.75m, data.CompetitorCommissionAmount);
        }

        [Fact]
        public void Calculate_ReturnsBadRequest_ForNegativeInput()
        {
            var controller = new CommisionController();

            var request = new CommissionCalculationRequest
            {
                LocalSalesCount = -1,
                ForeignSalesCount = 5,
                AverageSaleAmount = 100
            };

            var result = controller.Calculate(request);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}

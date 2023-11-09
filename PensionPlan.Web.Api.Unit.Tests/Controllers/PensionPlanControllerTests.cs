using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PensionPlan.Application.Services;
using PensionPlan.Web.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionPlan.Web.Api.Controllers.Unit.Tests
{
    [TestClass()]
    public class PensionPlanControllerTests
    {

        private PensionPlanController? planPensionController;
        private Mock<ILogger<PensionPlanController>>? loggerMock;
        private Mock<IPensionPlanService>? planPensionServiceMock;

        [TestInitialize]
        public void Setup()
        {
            loggerMock = new Mock<ILogger<PensionPlanController>>();
            planPensionServiceMock = new Mock<IPensionPlanService>();

            planPensionController = new PensionPlanController(loggerMock.Object, planPensionServiceMock.Object);
        }
               
        [TestMethod()]
        [DataRow(1000, 2000, 0, 12000, 570)]
        [DataRow(1000, 0, 3000, 18000, 960)]
        [DataRow(1000, 6000, 0, 30000, 2100)]
        [DataRow(1200, 0, 4000, 40000, 1924)]
        [DataRow(1500, 2000, 0, 90000,1575)]
        [DataRow(1400, 0, 8000, 400000, 4418)]
        public void CalculateTaxDeductionTest(int naturalPersonPensionPlan, int selfEmployedPensionPlan,
            int companyPensionPlan, int taxBase, int expectedResult)
        {
            planPensionServiceMock!.Setup(c => c.CalculateTaxDeduction(naturalPersonPensionPlan, selfEmployedPensionPlan,
                companyPensionPlan, taxBase)).Returns(expectedResult);

            var result = planPensionController!.CalculateTaxDeduction(naturalPersonPensionPlan, selfEmployedPensionPlan, 
                companyPensionPlan, taxBase);
            planPensionServiceMock.Verify(c => 
            c.CalculateTaxDeduction(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once());
            Assert.AreEqual(expectedResult, result);
        }
    }
}
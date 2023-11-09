using Microsoft.VisualStudio.TestTools.UnitTesting;
using PensionPlan.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionPlan.Application.Services.Integration.Tests
{
    [TestClass()]
    public class PensionPlanServiceTests
    {
        [TestMethod()]
        [DataRow(1000, 2000, 0, 12000, 570)]
        [DataRow(1000, 0, 3000, 18000, 960)]
        [DataRow(1000, 0, 6000, 30000, 2100)]
        [DataRow(1200, 0, 4000, 40000, 1924)]
        [DataRow(1500, 2000, 0, 90000, 1575)]
        [DataRow(1400, 0, 8000, 400000, 4418)]
        public void CalculateTaxDeductionTest(int naturalPersonPensionPlan, int selfEmployedPensionPlan,
           int companyPensionPlan, int taxBase, int expectedResult)
        {
            IPensionPlanService pensionPlanService = new PensionPlanService();
            int result = pensionPlanService.CalculateTaxDeduction(naturalPersonPensionPlan, selfEmployedPensionPlan,
                companyPensionPlan, taxBase);
            Assert.AreEqual(expectedResult,result);
        }
    }
}
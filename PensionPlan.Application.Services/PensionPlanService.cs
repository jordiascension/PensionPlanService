using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionPlan.Application.Services
{
    public class PensionPlanService : IPensionPlanService
    {

        public int CalculateTaxDeduction(int naturalPersonPensionPlan, int selfEmployedPensionPlan,
            int companyPensionPlan, int taxBase)
        {

            int deduction;
            int holding;
            int totalTaxBase;
            int planF = naturalPersonPensionPlan;
            int planA = selfEmployedPensionPlan;
            int planE = companyPensionPlan;

            if (naturalPersonPensionPlan > 1500) planF = 1500;
            else planF = naturalPersonPensionPlan;

            if (selfEmployedPensionPlan > 4250) planA = 4250;
            else planA = selfEmployedPensionPlan;

            if (companyPensionPlan > 8500) companyPensionPlan = 8500;
            else planE = companyPensionPlan;


            if ((naturalPersonPensionPlan == null) || (naturalPersonPensionPlan == 0))
            {
                totalTaxBase = planA + planE; 
            }
            else if ((selfEmployedPensionPlan == null) || (selfEmployedPensionPlan == 0))
            {
                totalTaxBase = planF + planE; 
            }
            else
            {
                totalTaxBase = planF + planA;
            }


            switch (taxBase) {

                case < 12450:
                    holding = 19;
                    deduction = (totalTaxBase * holding) /100;
                    break;

                case < 20199:
                    holding = 24;
                    deduction = (totalTaxBase * holding) / 100;
                    break;

                case < 35199:
                    holding = 30;
                    deduction = (totalTaxBase * holding) / 100;
                    break;

                case < 59999:
                    holding = 37;
                    deduction = (totalTaxBase * holding) / 100;
                    break;

                case < 299999:
                    holding = 45;
                    deduction = (totalTaxBase * holding) / 100;
                    break;

                default:
                    holding = 47;
                    deduction = (totalTaxBase * holding) / 100;
                    break;
             
            }

            return deduction;
        }
    }
}

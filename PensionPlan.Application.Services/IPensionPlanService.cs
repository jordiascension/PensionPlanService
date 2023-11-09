using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionPlan.Application.Services
{
    public interface IPensionPlanService
    {
        /// <summary>
        /// Se encarga de recoger las cantidades que se aportan al Plan de Pensiones y el Bruto Anual
        /// </summary>
        /// <param name="num1">Persona Física</param>
        /// <param name="num2">Autónomo</param>
        /// <param name="num3">Empresa</param>
        /// <param name="num4">Bruto Anual</param>
        /// <returns></returns>
        int CalculateTaxDeduction(int naturalPersonPensionPlan, int selfEmployedPensionPlan,
            int companyPensionPlan, int taxBase);
    }
}

using System;
namespace CloudEngineerBankingChallenge.Interfaces
{
    public interface ILoanService
    {
        /// <summary>
        /// Calculates the administration fee depend on the lower amount of it based on pre-configured terms and provided loan amount 
        /// </summary>
        /// <param name="loanAmount"></param>
        /// <returns>Amount of administration fee</returns>
        public double AdministrationFee(double loanAmount);

        /// <summary>
        /// Calculates monthly amount of the loan
        /// </summary>
        /// <param name="loanAmount"></param>
        /// <param name="loanDuration"></param>
        /// <returns>Monthly loan installment amount</returns>
        public double MonthlyCost(double loanAmount, double loanDuration);

        /// <summary>
        /// Calculates Annual Percentage Yield of the loan based on loan duration and defined annual interest rate
        /// </summary>
        /// <returns>APY - Annual Percentage Yield</returns>
        public double AnnualPercentageYield();

        /// <summary>
        /// Calculates the total amount of paid interest of the loan. It showing how much cost the loan without administration fees.
        /// </summary>
        /// <param name="loanAmount"></param>
        /// <param name="loanDuration"></param>
        /// <returns>Amount of paid interest of the loan</returns>
        public double TotalAmountPaidInterestRate(double loanAmount, double loanDuration);
    }
}

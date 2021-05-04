using System;
namespace CloudEngineerBankingChallenge.Interfaces
{
    public interface ILoanService
    {
        /// <summary>
        /// Calculates the administration fee depend on the lower amount of it based on pre-configured terms and provided load amount 
        /// </summary>
        /// <param name="loanAmount"></param>
        /// <returns>Amount of administration fee</returns>
        public double AdministrationFee(double loanAmount);

        public double MonthlyCost(double loanAmount, double loanDuration);

        public double AnnualPercentageYield();

        public double TotalAmountPaidInterestRate(double loanAmount, double loanDuration);
    }
}

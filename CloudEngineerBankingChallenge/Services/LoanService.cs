using System;
using CloudEngineerBankingChallenge.Interfaces;

namespace CloudEngineerBankingChallenge.Services
{
    public class LoanService : ILoanService
    {
        private readonly IConfigurationService Configuration;

        public LoanService(IConfigurationService configuration)
        {
            Configuration = configuration;
        }

        public double AdministrationFee(double loanAmount)
        {
            var fee = Configuration.AdministrationFeeAmount();

            if(fee > loanAmount * Configuration.AdministrationFeePercent())
            {
                return loanAmount * Configuration.AdministrationFeePercent();
            }

            return fee;
        }

        public double AnnualPercentageYield()
        {
            return Math.Pow((1 + Configuration.AnnualInterestRate() / 12), 12) - 1; ;
        }

        public double MonthlyCost(double loanAmount = 500000, double loanDuration = 10)
        {
            var percentageRatio = 1 + Configuration.MonthlyInterestRate();

            return loanAmount * Math.Pow(percentageRatio, loanDuration * 12) * ((percentageRatio - 1) / (Math.Pow(percentageRatio, loanDuration * 12) - 1)); ;
        }

        public double TotalAmountPaidInterestRate(double loanAmount, double loanDuration)
        {
            return MonthlyCost(loanAmount, loanDuration) * loanDuration * 12 - loanAmount;
        }
    }
}

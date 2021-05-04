using System;
namespace CloudEngineerBankingChallenge.Interfaces
{
    public interface IConfigurationService
    {
        public double AnnualInterestRate();

        public double MonthlyInterestRate();

        public double AdministrationFeeAmount();

        public double AdministrationFeePercent();
    }
}

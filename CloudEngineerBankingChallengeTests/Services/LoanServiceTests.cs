using System;
using CloudEngineerBankingChallenge.Interfaces;
using CloudEngineerBankingChallenge.Services;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CloudEngineerBankingChallengeTests.Services
{
    public class LoanServiceTests
    {
        private readonly ILoanService _service;

        private readonly IConfigurationService _configuration;

        public LoanServiceTests()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _configuration = new ConfigurationService(config);
            _service = new LoanService(_configuration);
        }

        [Theory]
        [InlineData(500000.00d)]
        public void CalculateAdministrationFeeTest(double loanAmount)
        {
            var result = _service.AdministrationFee(loanAmount);

            Assert.True(result <= _configuration.AdministrationFeeAmount());
        }

        [Fact]
        public void AnnualPercentageYieldTest()
        {
            var result = _service.AnnualPercentageYield();

            Assert.True(result > 0);
        }

        [Theory]
        [InlineData(500000d, 10d, 5303.28d)]
        public void MonthlyCostTest(double loanAmount, double loanDuration, double expectedResult)
        {
            var result = Math.Round(_service.MonthlyCost(loanAmount, loanDuration),2);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(500000d, 10d, 136393.09d)]
        public void TotalAmountPaidInterestRateTest(double loanAmount, double loanDuration, double expectedResult)
        {
            var result = Math.Round(_service.TotalAmountPaidInterestRate(loanAmount, loanDuration),2);

            Assert.Equal(expectedResult, result);
        }
    }
}

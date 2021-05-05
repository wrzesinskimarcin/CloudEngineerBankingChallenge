using CloudEngineerBankingChallenge.Interfaces;
using CloudEngineerBankingChallenge.Services;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CloudEngineerBankingChallengeTests.Services
{
    public class ConfigursationServiceTests
    {
        private readonly IConfigurationService _service;

        public ConfigursationServiceTests()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _service = new ConfigurationService(config);
        }

        [Theory]
        [InlineData(0.05d)]
        public void AnnualInterestRateTest(double expected)
        {
            var result = _service.AnnualInterestRate();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0.004166666666666667d)]
        public void MonthlyInterestRateTest(double expected)
        {
            var result = _service.MonthlyInterestRate();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(10000d)]
        public void AdministrationFeeAmountTest(double expected)
        {
            var result = _service.AdministrationFeeAmount();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0.01d)]
        public void AdministrationFeePercentTest(double expected)
        {
            var result = _service.AdministrationFeePercent();

            Assert.Equal(expected, result);
        }
    }
}

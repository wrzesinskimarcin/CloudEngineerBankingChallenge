using AutoFixture.Xunit2;
using CloudEngineerBankingChallenge.Controllers;
using CloudEngineerBankingChallenge.Interfaces;
using CloudEngineerBankingChallenge.Services;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace CloudEngineerBankingChallengeTests.Controllers
{
    public class PaymentOverviewControllerTests
    {
        private readonly PaymentOverviewController _controller;

        private readonly ILoanService _service;

        private readonly IConfigurationService _configuration;

        public PaymentOverviewControllerTests()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _configuration = new ConfigurationService(config);
            _service = new LoanService(_configuration);
            _controller = new PaymentOverviewController(_service);
        }

        [Theory, AutoData]
        public void PaymentOverviewTest(double loanAmount, double loanDuration)
        {
            var result = _controller.Get(loanAmount, loanDuration);

            Assert.NotEmpty(result);
        }
    }
}

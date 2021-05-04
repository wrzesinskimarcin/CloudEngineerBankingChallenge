﻿using System.Collections.Generic;
using System.Linq;
using CloudEngineerBankingChallenge.Interfaces;
using CloudEngineerBankingChallenge.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CloudEngineerBankingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentOverviewController : ControllerBase
    {
        private readonly ILogger<PaymentOverviewController> _logger;

        private readonly ILoanService _loanService;

        public PaymentOverviewController(ILogger<PaymentOverviewController> logger, ILoanService loanService)
        {
            _logger = logger;
            _loanService = loanService;
        }

        [HttpGet]
        [HttpGet("{loanAmount}/{loanDuration}")]
        public IEnumerable<PaymentOverviewResponse> Get(double loanAmount = 500000, double loanDuration = 10)
        {
            var danish = new System.Globalization.CultureInfo("da-DK");

            var yearOrYears = loanDuration > 1 ? "years" : "year";

            return Enumerable.Range(1, 1).Select(overview => new PaymentOverviewResponse
            {
                YearlyCost = _loanService.AnnualPercentageYield().ToString("P"),
                MonthlyCost = _loanService.MonthlyCost(loanAmount, loanDuration).ToString("C", danish),
                TotalAmountPaid = new TotalAmountPaid
                {
                    InterestRate = _loanService.TotalAmountPaidInterestRate(loanAmount, loanDuration).ToString("C", danish),
                    AdministrationFees = _loanService.AdministrationFee(loanAmount).ToString("C", danish)
                },
                Request = new RequestParameters
                {
                    LoanAmount = loanAmount.ToString("C", danish),
                    LoadDuration = $"{loanDuration} {yearOrYears}"
                }
            });
        }
    }
}

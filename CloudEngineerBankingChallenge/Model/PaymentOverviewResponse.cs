using System;
using System.Text.Json.Serialization;

namespace CloudEngineerBankingChallenge.Model
{
    public class PaymentOverviewResponse
    {
        [JsonPropertyName("ÅOP")]
        public string YearlyCost { get; set; } //expressed in danish krone 

        [JsonPropertyName("Monthly cost")]
        public string MonthlyCost { get; set; } //expressed in danish krone

        [JsonPropertyName("Total amount paid in")]
        public TotalAmountPaid TotalAmountPaid { get; set; }

        [JsonPropertyName("Request parameters")]
        public RequestParameters Request { get; set; }
    }

    public class TotalAmountPaid
    {
        [JsonPropertyName("Interest rate")]
        public string InterestRate { get; set; } //expressed in danish krone

        [JsonPropertyName("Administrative fees")]
        public string AdministrationFees { get; set; } //expressed in danish krone
    }

    public class RequestParameters
    {
        [JsonPropertyName("Loan amount")]
        public string LoanAmount { get; set; } //expressed in danish krone

        [JsonPropertyName("Loan duration")]
        public string LoadDuration { get; set; }  //expressed in months
    }
}

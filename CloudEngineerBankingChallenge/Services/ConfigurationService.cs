using CloudEngineerBankingChallenge.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CloudEngineerBankingChallenge.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration Configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public double AnnualInterestRate()
        {
            var air = Configuration.GetValue<double>("LoanConfiguration:AnnualInterestRate");

            return string.IsNullOrEmpty(air.ToString()) ? 0.05 : air;
        }

        public double MonthlyInterestRate()
        {
            var mir = Configuration.GetValue<string>("LoanConfiguration:MonthlyInterestRate");

            if (string.IsNullOrEmpty(mir))
            {
                return AnnualInterestRate() / 12;
            }

            return double.Parse(mir);
        }

        public double AdministrationFeeAmount()
        {
            var afa = Configuration.GetValue<double>("LoanConfiguration:AdministrationFee:Amount");

            return string.IsNullOrEmpty(afa.ToString()) ? 10000 : afa;
        }

        public double AdministrationFeePercent()
        {
            //default value
            double result = 0.01;

            var afp = Configuration.GetValue<string>("LoanConfiguration:AdministrationFee:Percent");

            if (!string.IsNullOrEmpty(afp))
            {
                //checks that value contain '%' which means that the user uses a string type of value that needs to be converted to double 
                if (afp.Contains("%"))
                {
                    afp = afp.Replace("%", "").Trim();

                    double.TryParse(afp, out result);

                    return result / 100;
                }

                double.TryParse(afp, out result);
            }

            return result;
        }
    }
}
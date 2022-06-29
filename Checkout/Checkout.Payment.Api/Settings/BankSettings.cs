namespace Checkout.Payment.Api.Settings
{
    public class BankSettings : IBankSettings
    {
        public string ApiUrl { get; set; }
        public string ProcessPaymentEndpoint { get; set; }

        public BankSettings()
        {
            ApiUrl = "http://localhost:5142";
            ProcessPaymentEndpoint = "payment";
        }
    }
}


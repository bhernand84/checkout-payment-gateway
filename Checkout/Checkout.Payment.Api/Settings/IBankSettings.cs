namespace Checkout.Payment.Api.Settings
{
    public interface IBankSettings
    {
        string ApiUrl { get; set; }
        string ProcessPaymentEndpoint { get; set; }
    }
}


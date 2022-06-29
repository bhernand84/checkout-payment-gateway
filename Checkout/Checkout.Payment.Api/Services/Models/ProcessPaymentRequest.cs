namespace Checkout.Payment.Api.Services.Models
{
    public class ProcessPaymentRequest
    {
        public string CardNumber
        { get; set; }
        public string ExpirationDate
        { get; set; }
        public decimal Amount
        { get; set; }
        public string Currency
        { get; set; }
        public string Cvv
        { get; set; }
        public ProcessPaymentRequest()
        {
        }
    }
}

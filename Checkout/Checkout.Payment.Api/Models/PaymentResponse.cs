using Checkout.Payment.Api.Models.Enum;

namespace Checkout.Payment.Api.Models
{
    public class PaymentResponse
    {
        public int Id
        { get; set; }
        public string PaymentId
        { get; set; }
        public PaymentStatusEnum PaymentStatus
        { get; set; }
        public string CardNumber
        { get; set; }
        public string ExpirationDate
        { get; set; }
        public decimal Amount
        { get; set; }
        public string Currency
        { get; set; }

        public PaymentResponse() { }
        public PaymentResponse(string paymentId, PaymentStatusEnum paymentStatus)
        {
            PaymentId = paymentId;
            PaymentStatus = paymentStatus;
        }

        public PaymentResponse(
            int id,
            string paymentId,
            PaymentStatusEnum paymentStatus,
            string cardNumber,
            string expirationDate,
            decimal amount,
            string currency)
        {
            Id = id;
            PaymentId = paymentId;
            PaymentStatus = paymentStatus;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            Amount = amount;
            Currency = currency;
        }
    }
}


using Checkout.Payment.Api.Models.Enum;

namespace Checkout.Payment.Api.Models
{
    public class PaymentResponse
    {
        public string PaymentId
        { get; set; }
        public PaymentStatusEnum PaymentStatus
        { get; set; }

        public PaymentResponse(string paymentId, PaymentStatusEnum paymentStatus)
        {
            PaymentId = paymentId;
            PaymentStatus = paymentStatus;
        }
    }
}


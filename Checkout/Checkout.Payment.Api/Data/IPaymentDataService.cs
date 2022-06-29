using Checkout.Payment.Api.Data.Models;

namespace Checkout.Payment.Api.Data
{
    public interface IPaymentDataService
    {
        Task Insert(PaymentItem paymentItem);
        Task<PaymentItem> Get(int id);
    }
}


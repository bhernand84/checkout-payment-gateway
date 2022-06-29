using Checkout.Payment.Api.Models;
using Checkout.Payment.Api.Services.Models;

namespace Checkout.Payment.Api.Services
{
    public interface IPaymentService
    {
        Task<PaymentResponse> ProcessPayment(ProcessPaymentRequest request);
        Task<int> PersistPayment(PaymentResponse response);
        Task<PaymentResponse> GetPayment(int id);
    }
}

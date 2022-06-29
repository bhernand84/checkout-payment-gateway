using Bank.Api.Models;

namespace Bank.Api.Services
{
    public class TestPaymentService : IPaymentService
    {
        public async Task<ProcessPaymentResponse> ProcessPayment(ProcessPaymentRequest request)
        {
            await Task.Delay(1);
            return new ProcessPaymentResponse()
            {
                PaymentID = "111"
            };
        }

        public TestPaymentService(){ }
    }
}


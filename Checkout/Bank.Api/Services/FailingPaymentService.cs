using System;
using Bank.Api.Models;

namespace Bank.Api.Services
{
    public class FailingPaymentService : IPaymentService
    {
        public async Task<ProcessPaymentResponse> ProcessPayment(ProcessPaymentRequest request)
        {
            await Task.Delay(1);
            return new ProcessPaymentResponse()
            {
                ErrorMessage = "Problem accessing Bank"
            };
        }

        public FailingPaymentService(){ }
    }
}


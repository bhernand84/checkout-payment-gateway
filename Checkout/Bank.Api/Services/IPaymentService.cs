using System;
using Bank.Api.Models;

namespace Bank.Api.Services
{
    public interface IPaymentService
    {
        Task<ProcessPaymentResponse> ProcessPayment(ProcessPaymentRequest request);
    }
}


using Bank.Api.Models;
using Bank.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<ProcessPaymentResponse> ProcessPayment(ProcessPaymentRequest paymentRequest)
    {
        var result = await _paymentService.ProcessPayment(paymentRequest);
        return result;
    }
}


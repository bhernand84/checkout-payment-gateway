using Checkout.Payment.Api.Models;
using Checkout.Payment.Api.Services;
using Checkout.Payment.Api.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Payment.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPayment(int id)
    {
        var result = await _paymentService.GetPayment(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> ProcessPayment(ProcessPaymentRequest paymentRequest)
    {
        var result = await _paymentService.ProcessPayment(paymentRequest);
        if (result.PaymentStatus == Models.Enum.PaymentStatusEnum.Success)
        {
            var id = await _paymentService.PersistPayment(result);
            return Ok(id);
        }
        return StatusCode((int)System.Net.HttpStatusCode.InternalServerError);
    }
}

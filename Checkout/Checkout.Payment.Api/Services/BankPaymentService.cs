using Checkout.Payment.Api.Models;
using Checkout.Payment.Api.Services.Models;
using Checkout.Payment.Api.Settings;
using RestSharp;

namespace Checkout.Payment.Api.Services
{
    public class BankPaymentService : IPaymentService
    {
        private readonly RestClient _client;
        private readonly IBankSettings _bankSettings;


        public async Task<PaymentResponse> ProcessPayment(ProcessPaymentRequest paymentRequest)
        {
            var request = new RestRequest(_bankSettings.ProcessPaymentEndpoint)
                            .AddJsonBody(paymentRequest);
            var response = await _client.ExecutePostAsync<ProcessPaymentResponse>(request);
            if (!response.IsSuccessful)
            {
                return new PaymentResponse(null, Api.Models.Enum.PaymentStatusEnum.Failure); 
            }

            if(response.Data == null || response.Data.ErrorMessage != null)
            {
                return new PaymentResponse(null, Api.Models.Enum.PaymentStatusEnum.Failure); 
            }

            return new PaymentResponse(response.Data.PaymentID, Api.Models.Enum.PaymentStatusEnum.Success);
        }

        public BankPaymentService(IBankSettings bankSettings)
        {
            _bankSettings = bankSettings;
            _client = new RestClient(_bankSettings.ApiUrl);
        }
    }
}


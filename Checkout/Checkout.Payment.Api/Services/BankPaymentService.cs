using Checkout.Payment.Api.Data;
using Checkout.Payment.Api.Extensions;
using Checkout.Payment.Api.Models;
using Checkout.Payment.Api.Models.Enum;
using Checkout.Payment.Api.Services.Models;
using Checkout.Payment.Api.Settings;
using RestSharp;

namespace Checkout.Payment.Api.Services
{
    public class BankPaymentService : IPaymentService
    {
        private readonly RestClient _client;
        private readonly IBankSettings _bankSettings;
        private IPaymentDataService _paymentDataService;

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

            return new PaymentResponse(
                0,
                response.Data.PaymentID,
                Api.Models.Enum.PaymentStatusEnum.Success,
                paymentRequest.CardNumber,
                paymentRequest.ExpirationDate,
                paymentRequest.Amount,
                paymentRequest.Currency);
        }

        public async Task<int> PersistPayment(PaymentResponse response)
        {
            var paymentItem = new Data.Models.PaymentItem(
                    response.PaymentId,
                    (int)response.PaymentStatus,
                    response.CardNumber,
                    response.ExpirationDate,
                    response.Amount,
                    response.Currency
                );
            await _paymentDataService.Insert(paymentItem);
            return paymentItem.Id;
        }

        public async Task<PaymentResponse> GetPayment(int id)
        {
            var response = new PaymentResponse();

            var item = await _paymentDataService.Get(id);
            
            if (item != null)
            {
                response = new PaymentResponse(
                item.Id,
                item.PaymentId,
                (PaymentStatusEnum)item.PaymentStatus,
                item.CardNumber.Mask(),
                item.ExpirationDate,
                item.Amount,
                item.Currency);
            }

            return response;
        }
        public BankPaymentService(IBankSettings bankSettings, IPaymentDataService paymentDataService)
        {
            _bankSettings = bankSettings;
            _client = new RestClient(_bankSettings.ApiUrl);
            _paymentDataService = paymentDataService;
        }
    }
}


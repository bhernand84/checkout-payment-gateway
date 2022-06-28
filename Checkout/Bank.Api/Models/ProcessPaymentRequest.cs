using System;
namespace Bank.Api.Models
{
    public class ProcessPaymentRequest
    {
        public string CardNumber
        { get; set; }
        public DateTime ExpirationDate
        { get; set; }
        public decimal Amount
        { get; set; }
        public string Currency
        { get; set; }
        public string Cvv
        { get; set; }
        public ProcessPaymentRequest()
        {
        }
    }
}


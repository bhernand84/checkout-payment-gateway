using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Checkout.Payment.Api.Models.Enum;

namespace Checkout.Payment.Api.Data.Models
{
    public class PaymentItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        { get; set; }
        public string PaymentId
        { get; set; }
        public int PaymentStatus
        { get; set; }
        public string CardNumber
        { get; set; }
        public string ExpirationDate
        { get; set; }
        public decimal Amount
        { get; set; }
        public string Currency
        { get; set; }

        public PaymentItem(string paymentId, int paymentStatus, string cardNumber, string expirationDate, decimal amount, string currency)
        {
            PaymentId = paymentId;
            PaymentStatus = paymentStatus;
            CardNumber = cardNumber;
            ExpirationDate = expirationDate;
            Amount = amount;
            Currency = currency;
        }
    }
}


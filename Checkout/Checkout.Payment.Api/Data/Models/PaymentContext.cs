using System;
using Microsoft.EntityFrameworkCore;

namespace Checkout.Payment.Api.Data.Models
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {

        }
        public DbSet<PaymentItem> PaymentItems { get; set; }
    }
}


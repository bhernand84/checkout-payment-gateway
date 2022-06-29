using Checkout.Payment.Api.Data.Models;

namespace Checkout.Payment.Api.Data
{
    public class PaymentDataService : IPaymentDataService
    {
        private readonly PaymentContext _context;

        public async Task Insert(PaymentItem paymentItem)
        {
            _context.PaymentItems.Add(paymentItem);
            await _context.SaveChangesAsync();
        }
        public async Task<PaymentItem> Get(int id)
        {
           return _context.PaymentItems.FirstOrDefault(m => m.Id == id);
        }

        public PaymentDataService(PaymentContext context)
        {
            _context = context;
        }
    }
}
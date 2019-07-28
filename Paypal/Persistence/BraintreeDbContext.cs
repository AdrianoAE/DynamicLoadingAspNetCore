using Braintree.PaymentMethods;
using Microsoft.EntityFrameworkCore;
using Payments.ConfigurationHelpers;

namespace Braintree.Persistence
{
    public class BraintreeDbContext : CustomDbContext<BraintreeDbContext>
    {
        public DbSet<Paypal> PaypalPayments { get; set; }
    }
}

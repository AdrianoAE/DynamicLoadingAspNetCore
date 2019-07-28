using Braintree.Persistence;
using Payments.Extensions;
using Payments.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Braintree.PaymentMethods
{
    public class Paypal : IPaymentMethod
    {
        public int Id { get; set; }
        public string Image { get; set; }

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        public string Create(string invoiceId, decimal amount)
        {
            //Payment Logic

            using var context = new BraintreeDbContext();

            var paypal = new Paypal { Image = "test" };

            context.PaypalPayments.Add(paypal);
            context.SaveChanges();

            return $"PaymentID: {paypal.Id}";
        }
        
        //═════════════════════════════════════════════════════════════════════════════════════════

        public Dictionary<string, object> Get(string paymentId)
        {
            using var context = new BraintreeDbContext();
            return context.PaypalPayments.FirstOrDefault().ToDictionary();
        }
    }
}

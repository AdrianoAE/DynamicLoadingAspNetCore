using Payments.Interfaces;
using System.Collections.Generic;
using System.Linq;
using EasyPay.Persistence;
using Payments.Extensions;

namespace EasyPay.PaymentMethods
{
    public class VisaMastercard : IPaymentMethod
    {
        public int Id { get; set; }
        public string Image { get; set; }

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        public string Create(string invoiceId, decimal amount)
        {
            //Payment Logic

            return $"PaymentID: {nameof(VisaMastercard)}";
        }

        //═════════════════════════════════════════════════════════════════════════════════════════

        public Dictionary<string, object> Get(string paymentId)
        {
            using var context = new EasyPayDbContext();
            return context.VisaMastercardPayments.FirstOrDefault().ToDictionary();
        }
    }
}

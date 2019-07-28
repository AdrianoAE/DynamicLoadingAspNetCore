using Payments.Extensions;
using Payments.Interfaces;
using System.Collections.Generic;
using System.Linq;
using EasyPay.Persistence;

namespace EasyPay.PaymentMethods
{
    public class Multibanco : IPaymentMethod
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Entity { get; set; }
        public string Reference { get; set; }
        public string Amount { get; set; }

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        public string Create(string invoiceId, decimal amount)
        {
            //Payment Logic

            return $"PaymentID: {nameof(Multibanco)}";
        }

        //═════════════════════════════════════════════════════════════════════════════════════════

        public Dictionary<string, object> Get(string paymentId)
        {
            using var context = new EasyPayDbContext();
            return context.MultibancoPayments.FirstOrDefault().ToDictionary();
        }
    }
}

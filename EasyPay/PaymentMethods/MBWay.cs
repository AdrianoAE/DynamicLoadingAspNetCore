using Payments.Interfaces;
using System.Collections.Generic;
using System.Linq;
using EasyPay.Persistence;
using Payments.Extensions;

namespace EasyPay.PaymentMethods
{
    public class MBWay : IPaymentMethod
    {
        public int Id { get; set; }
        public string Image { get; set; }

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        public string Create(string invoiceId, decimal amount)
        {
            //Payment Logic

            return $"PaymentID: {nameof(MBWay)}";
        }

        //═════════════════════════════════════════════════════════════════════════════════════════

        public Dictionary<string, object> Get(string paymentId)
        {
            using var context = new EasyPayDbContext();
            return context.MBWayPayments.FirstOrDefault().ToDictionary();
        }
    }
}

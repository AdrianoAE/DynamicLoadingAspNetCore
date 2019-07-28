using System.Collections.Generic;
using System.Linq;
using EasyPay.Persistence;
using Payments.Extensions;
using Payments.Interfaces;

namespace EasyPay.PaymentMethods
{
    public class BoletoBancario : IPaymentMethod
    {
        public int Id { get; set; }
        public string Image { get; set; }

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        public string Create(string invoiceId, decimal amount)
        {
            //Payment Logic
            using var context = new EasyPayDbContext();
            var paypal = new BoletoBancario { Image = "ImgBoleto" };
            context.BoletoBancarioPayments.Add(paypal);
            context.SaveChanges();

            return $"PaymentID: {paypal.Id}";
        }

        //═════════════════════════════════════════════════════════════════════════════════════════

        public Dictionary<string, object> Get(string paymentId)
        {
            using var context = new EasyPayDbContext();
            return context.BoletoBancarioPayments.FirstOrDefault().ToDictionary();
        }
    }
}

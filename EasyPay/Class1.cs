using Microsoft.Extensions.DependencyInjection;
using System;

namespace EasyPay
{
    public class EasyPay : IPaymentMethod
    {
        public string Name { get; set; }

        public EasyPay()
        {
            Name = "EasyPay Plugin";
        }

        public bool Equals(IPaymentMethod other)
        {
            throw new NotImplementedException();
        }
    }

    public class MasterCard : IPaymentMethod
    {
        public string Name { get; set; }

        public MasterCard()
        {
            Name = "MasterCard EasyPay";
        }

        public bool Equals(IPaymentMethod other)
        {
            throw new NotImplementedException();
        }
    }
}

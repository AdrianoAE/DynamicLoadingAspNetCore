using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace Paypal
{
    public class Paypal : IPaymentMethod
    {
        public string Name { get; set; }

        public Paypal()
        {
            Name = "Paypal Plugin";
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
            Name = "MasterCard Paypal";
        }

        public bool Equals(IPaymentMethod other)
        {
            throw new NotImplementedException();
        }
    }
}

using EasyPay.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Payments;
using Payments.Entities;
using Payments.Extensions;
using Payments.Interfaces;
using System.Collections.Generic;

namespace EasyPay
{
    public class EasyPay : IProvider
    {
        public string Image { get; }

        //═════════════════════════════════════════════════════════════════════════════════════════

        public IReadOnlyDictionary<string, IPaymentMethod> PaymentMethods => this.GetPaymentMethods();
        public FluentList<ProviderConfiguration> RequiredConfigurationFields { get; }

        public IPaymentMethod this[string key] => PaymentMethods[key];

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        public EasyPay(IServiceCollection services, string connectionString)
        {
            Image = "location";

            EasyPayDbContext.Configure(connectionString);

            RequiredConfigurationFields = new FluentList<ProviderConfiguration>()
                .Add(new ProviderConfiguration(nameof(Image)));
        }
    }
}

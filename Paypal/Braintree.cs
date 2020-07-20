using Braintree.Api;
using Braintree.Persistence;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payments;
using Payments.Entities;
using Payments.Extensions;
using Payments.Interfaces;
using System.Collections.Generic;

namespace Braintree
{
    public class Braintree : IProvider
    {
        public string Image { get; }

        public string ClientId { get; set; }
        public string SecretId { get; set; }

        //═════════════════════════════════════════════════════════════════════════════════════════

        public IReadOnlyDictionary<string, IPaymentMethod> PaymentMethods => this.GetPaymentMethods();
        public FluentList<ProviderConfiguration> RequiredConfigurationFields { get; }

        public IPaymentMethod this[string key] => PaymentMethods[key];

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        public Braintree(IServiceCollection services, /*IConfiguration configuration, IMediator med,*/ string connectionString)
        {
            Image = "location";

            BraintreeDbContext.Configure(connectionString);

            RequiredConfigurationFields = new FluentList<ProviderConfiguration>()
                .Add(new ProviderConfiguration(nameof(ClientId)))
                .Add(new ProviderConfiguration(nameof(SecretId)))
                .Add(new ProviderConfiguration(nameof(Image)));

            services.AddTransient<TestController>();
        }
    }
}

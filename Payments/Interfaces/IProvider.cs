using Payments.Entities;
using System.Collections.Generic;

namespace Payments.Interfaces
{
    public interface IProvider
    {
        string Image { get;}

        //═════════════════════════════════════════════════════════════════════════════════════════

        IReadOnlyDictionary<string, IPaymentMethod> PaymentMethods { get; }
        FluentList<ProviderConfiguration> RequiredConfigurationFields { get; }

        IPaymentMethod this[string key] { get; }
    }
}

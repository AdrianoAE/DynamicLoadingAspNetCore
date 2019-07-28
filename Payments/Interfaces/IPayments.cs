using Payments.Entities;
using System.Collections.Generic;

namespace Payments.Interfaces
{
    public interface IPayments
    {
        IReadOnlyDictionary<string, IProvider> Providers { get; }

        IProvider this[string key] { get; }

        //"Backoffice" Like experiment
        void ActivateModule(string name);
        List<Provider> GetProviders();
    }
}

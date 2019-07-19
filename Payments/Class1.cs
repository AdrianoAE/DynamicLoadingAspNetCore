using McMaster.NETCore.Plugins;
using System;
using System.Collections.Generic;
using System.Runtime.Loader;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddPayments(this IServiceCollection services)
        {
            services.AddSingleton<IPayments, Payments>();
        }
    }

    public interface IPayments
    {
        IReadOnlyDictionary<string, IPaymentMethod> PaymentMethods { get; }
    }

    public class Payments : IPayments
    {
        private readonly HotReloadManager<IPaymentMethod> _paymentMethods;

        IReadOnlyDictionary<string, IPaymentMethod> IPayments.PaymentMethods => _paymentMethods.Plugins;

        public Payments()
        {
            _paymentMethods = HotReloadManager<IPaymentMethod>.InitializeBasePath("Plugins");
            _paymentMethods.AssemblyUnloaded += OnAssemblyUnloaded;
            //_paymentMethods = HotReloadManager<IPaymentMethod>.InitializeFullPath(@"PATH\bin\Debug\netcoreapp3.0\Plugins\");
        }

        private void OnAssemblyUnloaded(AssemblyLoadContext obj)
        {
            //assembly unloaded
        }
    }

    //---------------------------------------------------------------------------------------------

    public interface IPaymentMethod : IEquatable<IPaymentMethod>
    {
        string Name { get; set; }
    }
}

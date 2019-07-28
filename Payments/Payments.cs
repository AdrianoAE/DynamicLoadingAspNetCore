using McMaster.NETCore.Plugins.Manager;
using Microsoft.EntityFrameworkCore;
using Payments.Entities;
using Payments.Interfaces;
using Payments.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Payments
{
    public class PaymentsManager : IPayments
    {
        private readonly ModuleManager<IProvider> _providers;
        public IReadOnlyDictionary<string, IProvider> Providers => _providers.Modules;

        public IProvider this[string key] => _providers.Modules[key];

        #region --- Backoffice ---

        public void ActivateModule(string name)
        {
            _providers.ActivateModule(name);
        }

        public List<Provider> GetProviders()
        {
            using var context = new PaymentsDbContext();
            return context.Providers.ToList();
        }
        #endregion

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        public PaymentsManager(string path, string connectionString)
        {
            PaymentsDbContext.Configure(connectionString);

            using var context = new PaymentsDbContext();

            var paymentMethods = context.Providers.Include(p => p.Configuration).ToList();
            var activeMethods = paymentMethods.Where(IsValidProvider).Select(p => p.Name).ToList();

            _providers = FluentModuleManager<IProvider>.WithPath(path)
                .WithModuleParameters(connectionString)
                .EnableHotReload()
                .EnableOnLoadSetInactive()
                .SetModulesToLoadAtStartup(activeMethods)
                .Complete();

            var names = paymentMethods.Select(p => p.Name).ToList();
            var newPaymentMethods = _providers.Modules.Union(_providers.InactiveModules).Where(m => !names.Contains(m.Key)).ToList();
            if (newPaymentMethods.Count > 0)
            {
                context.Providers.AddRange(newPaymentMethods.Select(m => new Provider(m.Key, m.Value.RequiredConfigurationFields)));
                context.SaveChanges();
            }                

            _providers.ModuleLoaded += ProviderAdded;
            _providers.ModuleUnLoaded += ProviderRemoved;

            _providers.InactiveModuleLoaded += ProviderAdded;
        }

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        private void ProviderAdded(object sender, ModuleEventArgs<IProvider> e)
        {
            using var context = new PaymentsDbContext();

            var method = context.Providers.Where(p => p.Name == e.ModuleName).Include(p => p.Configuration).FirstOrDefault();
            if (method == null)
            {
                context.Providers.Add(new Provider(e.ModuleName, e.Value.RequiredConfigurationFields));
                context.SaveChanges();
            }
            else
            {
                if (IsValidProvider(method))
                {
                    _providers.ActivateModule(method.Name);
                }
            }
        }

        //═════════════════════════════════════════════════════════════════════════════════════════

        private void ProviderRemoved(object sender, UnloadEventArgs e)
        {
            using var context = new PaymentsDbContext();

            var method = context.Providers.FirstOrDefault(p => p.Name == e.ModuleName);
            if (method != null)
            {
                method.IsActive = false;
                context.SaveChanges();
            }
        }

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        private bool IsValidProvider(Provider provider)
        {
            return provider.IsActive && !provider.Configuration.Any(c => string.IsNullOrWhiteSpace(c.Value));
        }
    }
}

using Payments;
using Payments.API;
using Payments.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddPayments(this IServiceCollection services, string path, string connectionString)
        {
            services.AddSingleton<IPayments>(p => p.ResolveWith<PaymentsManager>(services, path, connectionString));
            services.AddTransient<ModuleController>();
        }
    }
}

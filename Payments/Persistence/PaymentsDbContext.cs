using Microsoft.EntityFrameworkCore;
using Payments.ConfigurationHelpers;
using Payments.Entities;

namespace Payments.Persistence
{
    internal class PaymentsDbContext : CustomDbContext<PaymentsDbContext>
    {
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderConfiguration> ProvidersConfiguration { get; set; }
    }
}

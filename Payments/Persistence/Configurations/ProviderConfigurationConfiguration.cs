using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payments.Entities;

namespace Payments.Persistence.Configurations
{
    internal class ProviderConfigurationConfiguration : IEntityTypeConfiguration<ProviderConfiguration>
    {
        public void Configure(EntityTypeBuilder<ProviderConfiguration> builder)
        {
            builder.HasKey(pc => new { pc.ProviderId, pc.PropertyName });

            builder.Property(pc => pc.PropertyName).IsRequired();
        }
    }
}

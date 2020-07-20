using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payments.Entities;

namespace Payments.Persistence.Configurations
{
    internal class ProviderConfigurations : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.Property(p => p.IsActive).IsRequired();
        }
    }
}

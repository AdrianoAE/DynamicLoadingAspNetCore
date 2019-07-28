using EasyPay.PaymentMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyPay.Persistence.Configurations
{
    public class MultibancoConfiguration : IEntityTypeConfiguration<Multibanco>
    {
        public void Configure(EntityTypeBuilder<Multibanco> builder)
        {
            builder.Property(p => p.Image).IsRequired();
        }
    }
}

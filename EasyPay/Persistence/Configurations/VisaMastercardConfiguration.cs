using EasyPay.PaymentMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyPay.Persistence.Configurations
{
    public class VisaMastercardConfiguration : IEntityTypeConfiguration<VisaMastercard>
    {
        public void Configure(EntityTypeBuilder<VisaMastercard> builder)
        {
            builder.Property(p => p.Image).IsRequired();
        }
    }
}

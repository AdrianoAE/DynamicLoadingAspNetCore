using EasyPay.PaymentMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyPay.Persistence.Configurations
{
    public class DebitoDiretoConfiguration : IEntityTypeConfiguration<DebitoDireto>
    {
        public void Configure(EntityTypeBuilder<DebitoDireto> builder)
        {
            builder.Property(p => p.Image).IsRequired();
        }
    }
}

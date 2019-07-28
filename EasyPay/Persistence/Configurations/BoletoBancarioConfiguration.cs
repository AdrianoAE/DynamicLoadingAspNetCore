using EasyPay.PaymentMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyPay.Persistence.Configurations
{
    public class BoletoBancarioConfiguration : IEntityTypeConfiguration<BoletoBancario>
    {
        public void Configure(EntityTypeBuilder<BoletoBancario> builder)
        {
            builder.Property(p => p.Image).IsRequired();
        }
    }
}

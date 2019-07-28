using EasyPay.PaymentMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyPay.Persistence.Configurations
{
    public class MBWayConfiguration : IEntityTypeConfiguration<MBWay>
    {
        public void Configure(EntityTypeBuilder<MBWay> builder)
        {
            builder.Property(p => p.Image).IsRequired();
        }
    }
}

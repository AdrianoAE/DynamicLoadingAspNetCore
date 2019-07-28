using Braintree.PaymentMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Braintree.Persistence.Configurations
{
    public class PaypalConfiguration : IEntityTypeConfiguration<Paypal>
    {
        public void Configure(EntityTypeBuilder<Paypal> builder)
        {
            builder.Property(p => p.Image).IsRequired();
        }
    }
}

using EasyPay.PaymentMethods;
using Microsoft.EntityFrameworkCore;
using Payments.ConfigurationHelpers;

namespace EasyPay.Persistence
{
    public class EasyPayDbContext : CustomDbContext<EasyPayDbContext>
    {
        public DbSet<BoletoBancario> BoletoBancarioPayments { get; set; }
        public DbSet<DebitoDireto> DebitoDiretoPayments { get; set; }
        public DbSet<MBWay> MBWayPayments { get; set; }
        public DbSet<Multibanco> MultibancoPayments { get; set; }
        public DbSet<VisaMastercard> VisaMastercardPayments { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;

namespace Payments.ConfigurationHelpers
{
    public class CustomDbContext<T> : DbContext where T : DbContext
    {
        private static string _connectionString;
        private readonly string _defaultSchema = typeof(T).Name.Replace("DbContext", "");

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        public static void Configure(string connectionString)
        {
            _connectionString = connectionString;

            using var context = (T)Activator.CreateInstance(typeof(T));
            context.Database.Migrate();
        }

        //═════════════════════════════════════════════════════════════════════════════════════════

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var _migrationConnectionString = "Server=(localdb)\\mssqllocaldb;Database=Development;Trusted_Connection=True;Application Name=Dev;";
            var _migrationTableName = "__PaymentMethodMigrationsHistory";

            optionsBuilder.UseSqlServer(_connectionString ?? _migrationConnectionString, options =>
            {
                options.MigrationsHistoryTable(_migrationTableName, _defaultSchema);
            });
        }

        //═════════════════════════════════════════════════════════════════════════════════════════

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(_defaultSchema);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(T).Assembly);
        }

        //═════════════════════════════════════════════════════════════════════════════════════════

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}

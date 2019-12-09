using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payments.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Payments.ConfigurationHelpers
{
    public class CustomDbContext<T> : DbContext where T : DbContext
    {
        private class Translation
        { }
        private DbSet<Translation> MyProperty { get; set; }


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
            var teste = new Dictionary<string, string>();

            foreach (var entity in new List<IMutableEntityType>(modelBuilder.Model.GetEntityTypes()))
            {
                var propertiesWithTranslation = new Dictionary<string, IMutableProperty>();

                foreach (var property in entity.GetProperties().Where(p => p.Name.Contains("Translated")))
                {
                    teste.Add(entity.Name, property.Name);
                    propertiesWithTranslation.Add(property.Name.Replace("Translated", ""), property);
                }

                if (propertiesWithTranslation?.Count > 0)
                {
                    modelBuilder.Entity<Translation>(b =>
                    {
                        string translationTableName = $"{entity.GetTableName()}Translations";
                        b.ToTable(translationTableName);

                        string entityFk = $"{entity.GetTableName()}Id";
                        string languagueFk = "LanguageId";

                        b.Property<int>(languagueFk).IsRequired();
                        b.Property<int>(entityFk).IsRequired();

                        b.HasKey(new string[] { entityFk, languagueFk });

                        foreach (var property in propertiesWithTranslation)
                        {
                            //b.Property<string>(property.Key);
                            b.MissionComplete(property.Key, property.Value);
                        }

                        //MethodInfo SetGlobalQueryMethod = typeof(CustomDbContext<T>).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                        //                                .Single(t => t.IsGenericMethod && t.Name == "SetGlobalQuery");

                        //var method = SetGlobalQueryMethod.MakeGenericMethod(typeof(Translation), entity.ClrType);
                        //method.Invoke(this, new object[] { b, entityFk });
                    });
                }
            }

            foreach (var item in teste)
            {
                modelBuilder.Entity(item.Key).Ignore(item.Value);
            }

            //foreach (var entityType in modelBuilder.Model.GetEntityTypes().Where(e => !e.IsOwned() && !e.IsKeyless))
            //{
            //    modelBuilder.Entity(entityType.Name).Property<DateTime>("Created");
            //    modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified");
            //}
        }

        public void SetGlobalQuery<K, Y>(EntityTypeBuilder<K> builder, string key) where K : class
                                                                                   where Y : class
        {
            builder.HasOne<Y>()
                .WithMany()
                .HasForeignKey(key);
        }

        //═════════════════════════════════════════════════════════════════════════════════════════

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var timestamp = DateTime.Now;

            foreach (var entry in ChangeTracker.Entries().Where(e => (e.State == EntityState.Added || e.State == EntityState.Modified) && !e.Metadata.IsOwned()))
            {
                entry.Property("LastModified").CurrentValue = timestamp;

                if (entry.State == EntityState.Added)
                {
                    entry.Property("Created").CurrentValue = timestamp;
                }
            }

            return base.SaveChanges();
        }
    }
}

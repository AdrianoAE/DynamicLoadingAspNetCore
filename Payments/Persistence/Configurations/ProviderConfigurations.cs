using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payments.Entities;
using System;
using System.Linq.Expressions;

namespace Payments.Persistence.Configurations
{
    internal class ProviderConfigurations : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.PropertyWithTranslation(p => p.Name).HasMaxLength(500).IsRequired();

            builder.Property(p => p.IsActive).IsRequired();
        }
    }
          

    public static class teste
    {
        public static PropertyBuilder<string> PropertyWithTranslation<TSource>(this EntityTypeBuilder<TSource> builder, Expression<Func<TSource, string>> propertyExpression) where TSource : class
        {
            string propertyName = ((MemberExpression)propertyExpression.Body).Member.Name;
            builder.Ignore(propertyName);
            return new PropertyBuilder<string>(builder.Property<string>($"Translated{propertyName}").Metadata);
        }

        public static PropertyBuilder<string> MissionComplete<TSource>(this EntityTypeBuilder<TSource> builder, string name, IMutableProperty teste) where TSource : class
        {
            var x = teste.GetAnnotations();

            var y = builder.Property<string>(name).Metadata;
            foreach (var item in x)
            {
                y.SetAnnotation(item.Name, item.Value);
            }

            return new PropertyBuilder<string>(y);
        }
    }
}

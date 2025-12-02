using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whzan_API.EF.Models;

namespace Whzan_API.EF.Configurations
{
    public class ProductCurrencyConfig : IEntityTypeConfiguration<ProductCurrency>
    {
        public void Configure(EntityTypeBuilder<ProductCurrency> builder)
        {
            builder.Property(property => property.CurrencyId).IsRequired();
            builder.Property(property => property.ProductId).IsRequired();

            builder
                .HasOne(e => e.Product)
                .WithMany(e => e.ProductCurrencies)
                .HasForeignKey(e => e.ProductId)
                .IsRequired();

            builder
                .HasOne(e => e.Currency)
                .WithMany(e => e.ProductCurrencies)
                .HasForeignKey(e => e.CurrencyId)
                .IsRequired();
        }
    }
}

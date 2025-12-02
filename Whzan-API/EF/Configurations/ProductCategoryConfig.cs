using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whzan_API.EF.Models;

namespace Whzan_API.EF.Configurations
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(property => property.CategoryId).IsRequired();
            builder.Property(property => property.ProductId).IsRequired();

            builder
                .HasOne(e => e.Product)
                .WithMany(e => e.ProductCategories)
                .HasForeignKey(e => e.ProductId)
                .IsRequired();

            builder
                .HasOne(e => e.Category)
                .WithMany(e => e.ProductCategories)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired();
        }
    }
}

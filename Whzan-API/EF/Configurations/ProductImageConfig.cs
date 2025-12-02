using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whzan_API.EF.Models;
using Whzan_API.EF.SeedingData;

namespace Whzan_API.EF.Configurations
{
    public class ProductImageConfig : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.Property(property => property.ImageId).IsRequired();
            builder.Property(property => property.ProductId).IsRequired();

            builder
                .HasOne(e => e.Product)
                .WithMany(e => e.ProductImages)
                .HasForeignKey(e => e.ProductId)
                .IsRequired();

            builder
                .HasOne(e => e.Image)
                .WithMany(e => e.ProductImages)
                .HasForeignKey(e => e.ImageId)
                .IsRequired();
        }
    }
}

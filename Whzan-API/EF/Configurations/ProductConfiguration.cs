using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whzan_API.EF.Models;
using Whzan_API.EF.SeedingData;

namespace Whzan_API.EF.Congigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(property => property.Name).IsRequired();
            builder.Property(property => property.Description).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whzan_API.EF.Models;

namespace Whzan_API.EF.Configurations
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(property => property.Name).IsRequired();

            builder
               .HasOne(e => e.Product)
               .WithMany(e => e.Tags)
               .HasForeignKey(e => e.ProductId)
               .IsRequired();
        }
    }
}

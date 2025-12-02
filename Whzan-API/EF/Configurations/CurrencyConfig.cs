using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Whzan_API.EF.Models;

namespace Whzan_API.EF.Configurations
{
    public class CurrencyConfig : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.Property(property => property.Code).IsRequired();
            builder.Property(property => property.Name).IsRequired();

            builder.HasData(
                new Currency()
                {
                    Id = 1,
                    Code = "$",
                    Name = "US Dollar"
                },
                new Currency()
                {
                    Id = 2,
                    Code = "R",
                    Name = "Rand"
                }
           );
        }
    }
}

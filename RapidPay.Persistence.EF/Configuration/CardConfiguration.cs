using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidPay.Core.Entities;

namespace RapidPay.Persistence.EF.Configuration
{
    internal class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Number).IsRequired().HasMaxLength(15);
        }
    }
}

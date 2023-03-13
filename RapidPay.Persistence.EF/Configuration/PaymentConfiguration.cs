using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidPay.Core.Entities;

namespace RapidPay.Persistence.EF.Configuration
{
    internal class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.CardId).IsRequired();
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.Date).IsRequired();

            builder.HasIndex(p => p.CardId);
        }
    }
}

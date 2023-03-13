using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RapidPay.Core.Entities;

namespace RapidPay.Persistence.EF.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Username).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(30);

            builder.HasData(
                new User
                {
                    Id = new Guid("cce3570b-6d75-4fdb-9d99-554fac6fb164"),
                    Username = "admin",
                    Password = "admin123",
                    Role = "admin"
                },
                new User
                {
                    Id = new Guid("b27a4e94-c919-4bf8-9174-1be8b33cbb87"),
                    Username = "guest",
                    Password = "guest123",
                    Role = "guest"
                }
            );
        }
    }
}

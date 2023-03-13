using Microsoft.EntityFrameworkCore;
using RapidPay.Core.Entities;
using System.Reflection;

namespace RapidPay.Persistence.EF.Persistence
{
    public class RapidPayDbContext : DbContext
    {
        public RapidPayDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

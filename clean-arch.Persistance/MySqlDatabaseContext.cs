using clean_arch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace clean_arch.Persistence
{
    public class MySqlDatabaseContext : DbContext
    {
        public MySqlDatabaseContext(DbContextOptions<MySqlDatabaseContext> options)
            : base(options)
        {
        }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MySqlDatabaseContext).Assembly);

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Amount).IsRequired();
                entity.Property(e => e.Date).IsRequired();

            });
        }
    }
}
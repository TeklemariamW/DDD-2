using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Customer> Owners { get; set; }
        // public DbSet<Order>? Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuring Students
            modelBuilder.Entity<Customer>()
                        .ToContainer("Customers")
                        .HasPartitionKey(c => c.CustomerId)
                        .OwnsMany(o => o.Orders);
        }
    }
}

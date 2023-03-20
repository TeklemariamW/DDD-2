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
        public DbSet<Customer>? Owners { get; set; }
        public DbSet<Order>? Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configuring Students
            modelBuilder.Entity<Customer>()
                        .ToContainer("Customers")
                        .HasPartitionKey(c => c.CustomerId)
                        .OwnsMany(o => o.Orders);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<LogMessage>(entity =>
        //    {
        //        entity.ToContainer("LogMessage");
        //        entity.HasNoDiscriminator();
        //        entity.Property(m => m.Id)
        //               .HasConversion(
        //                    identity => identity.Value,
        //                    guid => new LogMessageId(guid)
        //                );

        //        entity.Property(p => p.ProjectId)
        //               .HasConversion(
        //                    identity => identity.Value,
        //                    guid => new LDRModels.Domain.Entities.Projects.ProjectId(guid)
        //                );
        //        entity.Property(c => c.ContractorId)
        //               .HasConversion(
        //                    identity => identity.Value,
        //                    guid => new LDRModels.Domain.Entities.Contractors.ContractorId(guid)
        //                );
        //        entity.OwnsOne(m => m.Message).Property(m => m.Id)
        //               .HasConversion(
        //                    identity => identity.Value,
        //                    guid => new MessageId(guid)
        //                );
        //    });
        //}
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferManagement.Domain.Entities;

namespace OfferManagement.Infrastructure.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(200).IsRequired();

            builder.HasData(
                new Supplier { Id = 1, Name = "Major Auto", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 2, Name = "Avilon", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 3, Name = "Rolf", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 4, Name = "AutoSpecCenter", CreatedAt = DateTime.UtcNow },
                new Supplier { Id = 5, Name = "Inchcape", CreatedAt = DateTime.UtcNow }
            );
        }
    }
}

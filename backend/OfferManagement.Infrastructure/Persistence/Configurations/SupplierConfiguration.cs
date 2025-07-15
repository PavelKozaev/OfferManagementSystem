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
                new Supplier { Id = 1, Name = "Major Auto", CreatedAt = new DateTime(2025, 7, 15, 12, 0, 0, DateTimeKind.Utc) },
                new Supplier { Id = 2, Name = "Avilon", CreatedAt = new DateTime(2025, 7, 15, 12, 0, 0, DateTimeKind.Utc) },
                new Supplier { Id = 3, Name = "Rolf", CreatedAt = new DateTime(2025, 7, 15, 12, 0, 0, DateTimeKind.Utc) },
                new Supplier { Id = 4, Name = "AutoSpecCenter", CreatedAt = new DateTime(2025, 7, 15, 12, 0, 0, DateTimeKind.Utc) },
                new Supplier { Id = 5, Name = "Inchcape", CreatedAt = new DateTime(2025, 7, 15, 12, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}

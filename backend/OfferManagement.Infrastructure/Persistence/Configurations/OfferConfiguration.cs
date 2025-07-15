using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfferManagement.Domain.Entities;

namespace OfferManagement.Infrastructure.Persistence.Configurations
{
    public class OfferConfiguration : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Brand).HasMaxLength(100).IsRequired();
            builder.Property(o => o.Model).HasMaxLength(100).IsRequired();

            builder.HasOne(o => o.Supplier)
                .WithMany(s => s.Offers)
                .HasForeignKey(o => o.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Offer { Id = 1, Brand = "Toyota", Model = "Camry", SupplierId = 1, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 2, Brand = "Toyota", Model = "RAV4", SupplierId = 1, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 3, Brand = "BMW", Model = "X5", SupplierId = 2, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 4, Brand = "BMW", Model = "3 Series", SupplierId = 2, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 5, Brand = "Mercedes-Benz", Model = "E-Class", SupplierId = 2, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 6, Brand = "Audi", Model = "A6", SupplierId = 3, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 7, Brand = "Audi", Model = "Q7", SupplierId = 3, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 8, Brand = "Hyundai", Model = "Solaris", SupplierId = 3, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 9, Brand = "Kia", Model = "Rio", SupplierId = 3, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 10, Brand = "Volkswagen", Model = "Tiguan", SupplierId = 4, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 11, Brand = "Volkswagen", Model = "Polo", SupplierId = 4, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 12, Brand = "Skoda", Model = "Octavia", SupplierId = 4, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 13, Brand = "Lada", Model = "Vesta", SupplierId = 5, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 14, Brand = "Lada", Model = "Granta", SupplierId = 5, RegisteredAt = DateTime.UtcNow },
                new Offer { Id = 15, Brand = "Ford", Model = "Focus", SupplierId = 1, RegisteredAt = DateTime.UtcNow }
            );
        }
    }
}

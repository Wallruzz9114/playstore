using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Playstore.Domain.Abstractions;
using Playstore.Domain.Entities;

namespace Playstore.Infrastructure.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasColumnType("varchar(250)");
            builder.Property(c => c.Description).IsRequired().HasColumnType("varchar(500)");
            builder.Property(c => c.Image).IsRequired().HasColumnType("varchar(250)");

            builder.OwnsOne(c => c.Dimensions, cm =>
            {
                cm.Property(c => c.Length).HasColumnName(nameof(Dimensions.Length)).HasColumnType("int");
                cm.Property(c => c.Width).HasColumnName(nameof(Dimensions.Length)).HasColumnType("int");
                cm.Property(c => c.Height).HasColumnName(nameof(Dimensions.Height)).HasColumnType("int");
            });
        }
    }
}
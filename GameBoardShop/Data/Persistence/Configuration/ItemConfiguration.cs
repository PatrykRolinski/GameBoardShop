using GameBoardShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Persistence.Configuration
{
    internal class ItemConfiguration: IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(i=> i.Producer)
                .WithMany()
                .HasForeignKey(i=> i.ProducerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.GameCategories)
                .WithMany();
        }
    }
}

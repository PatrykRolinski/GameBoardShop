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

            builder.HasMany(i => i.GameCategories)
                .WithMany();

            builder.HasMany(i => i.Price)
                .WithOne(p=> p.Item)
                .HasForeignKey(p=> p.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

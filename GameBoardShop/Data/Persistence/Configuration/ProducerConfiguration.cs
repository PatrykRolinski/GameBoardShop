using GameBoardShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal class ProducerConfiguration : IEntityTypeConfiguration<Producer>
    {
        public void Configure(EntityTypeBuilder<Producer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(i => i.Name)
                 .HasMaxLength(50)
                 .IsRequired();

            builder.HasMany(p => p.Items)
                .WithOne(i => i.Producer)
                .HasForeignKey(i => i.ProducerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

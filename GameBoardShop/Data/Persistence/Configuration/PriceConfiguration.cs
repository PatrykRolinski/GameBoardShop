using GameBoardShop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameBoardShop.Data.Persistence.Configuration
{
    internal class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DateTime)
                .HasColumnType("smalldatetime")
                .HasDefaultValueSql("convert(smalldatetime, GETUTCDATE())");

            builder.Property(p => p.Value)
                .HasColumnType("decimal(8,2)");

            
        }
    }
}

using GameBoardShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Persistence.Configuration
{
    internal class GameCategoryConfiguration: IEntityTypeConfiguration<GameCategory>
    {
        public void Configure(EntityTypeBuilder<GameCategory> builder)
        {
            builder.HasData(
                new GameCategory { Id = 1, Name = "Action" },
                new GameCategory { Id = 2, Name = "Strategy" },
                new GameCategory { Id = 3, Name = "Role-playing" },
                new GameCategory { Id = 4, Name = "Sports" },
                new GameCategory { Id = 5, Name = "Adventure" });

        }
    }
}

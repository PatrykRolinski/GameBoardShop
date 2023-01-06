using GameBoardShop.Data.Persistence.Configuration;
using GameBoardShop.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Configuration;

namespace Persistence
{
    public class GameBoardShopContext : DbContext
    {
        public GameBoardShopContext(DbContextOptions<GameBoardShopContext> options) : base(options)
        {

        }

        public DbSet<Item> Items => Set<Item>();
        public DbSet<Producer> Producers => Set<Producer>();
        public DbSet<GameCategory> GameCategories => Set<GameCategory>();
        public DbSet<Price> Prices => Set<Price>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ItemConfiguration().Configure(modelBuilder.Entity<Item>());
            new PriceConfiguration().Configure(modelBuilder.Entity<Price>());
            new ProducerConfiguration().Configure(modelBuilder.Entity<Producer>());
            new GameCategoryConfiguration().Configure(modelBuilder.Entity<GameCategory>());
        }
    }
}

using GameBoardShop.Models;
using Microsoft.EntityFrameworkCore;


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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

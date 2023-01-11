using GameBoardShop.Data.Contracts.IServices;
using GameBoardShop.Data.Contracts.Persistence;
using GameBoardShop.Data.Persistence.Repositories;
using GameBoardShop.Data.Services;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceWithEFRegistration
    {
        public static IServiceCollection AddGameBoardShopPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<GameBoardShopContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("AppDbConnection"));
            });

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProducerRepository, ProducerRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IGameCategoryRepository, GameCategoryRepository>();

            return services;

        }
    }
}

using GameBoardShop.Data.Contracts.Persistence;
using GameBoardShop.Data.Persistence.Repositories;
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

            return services;

        }
    }
}

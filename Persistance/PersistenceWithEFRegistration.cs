using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            return services;
        }
    }
}

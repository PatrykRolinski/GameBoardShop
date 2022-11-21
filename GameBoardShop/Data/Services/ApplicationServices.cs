using GameBoardShop.Data.Contracts.IServices;

namespace GameBoardShop.Data.Services
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services)
        {
            services.AddScoped<IProducerService, ProducerService>();

            return services;
        }
    }
}

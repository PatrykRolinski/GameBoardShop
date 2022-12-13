using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace IntegrationTests;

public static class ServiceCollectionExtensions
{
    public static void RemoveDbContext<T> (this IServiceCollection services) where T : DbContext
    {
        var desciptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<T>));
        if(desciptor != null) services.Remove(desciptor);
    }

    public static void EnsureDbCreated<T>(this IServiceCollection services) where T: DbContext
    {
        var serviceProvider = services.BuildServiceProvider();

        using var scope = serviceProvider.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var context = scopedServices.GetRequiredService<T>();
        context.Database.EnsureCreated();
    }
}

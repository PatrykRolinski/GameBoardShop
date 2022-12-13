using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;


namespace IntegrationTests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {

            // Remove GameBoardShopContext
            services.RemoveDbContext<GameBoardShopContext>();

            //Add DbContext
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            services.AddDbContext<GameBoardShopContext>(options => options.UseSqlite(connection));

            //Ensure schema get created
            services.EnsureDbCreated<GameBoardShopContext>();

        });
    }
}

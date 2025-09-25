using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using DMS.DesktopApp.Properties;
using Microsoft.Extensions.Configuration;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json")
                       .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContextFactory<ApplicationDbContext>(options =>
            options.UseMySql(connectionString: connectionString, 
            new MySqlServerVersion(new Version(8, 0, 27)), mySqlOptions => mySqlOptions.CommandTimeout(300)));


        // Register IMemoryCache
        services.AddMemoryCache();

        services.AddScoped<ITranslationService, TranslationService>();
    }

    public void Configure(IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((context, services) => ConfigureServices(services));
    }
}

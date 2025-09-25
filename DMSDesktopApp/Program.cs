using DMS.Context.Data;
using DMS.DesktopApp.Helpers.Translations;
using DMS.DesktopApp.Shared;
using DMS.DesktopApp.Sync;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Security;
using System.Configuration;

namespace DMSDesktopApp
{
    internal static class Program
    {

        //private static string serverName = EncryptDecrypt.Decrypt(DMS.DesktopApp.Properties.Settings.Default.ServerName);
        //private static string database = EncryptDecrypt.Decrypt(DMS.DesktopApp.Properties.Settings.Default.Database);
        //private static string uID = EncryptDecrypt.Decrypt(DMS.DesktopApp.Properties.Settings.Default.UID);
        //private static string password = EncryptDecrypt.Decrypt(DMS.DesktopApp.Properties.Settings.Default.Password);
        //private static string connectionString = $"server={serverName};port=3306;database={database};uid={uID};password={password};AllowLoadLocalInfile=true;";

        private static readonly ApplicationDbContext _dbContext;
        private static readonly IMemoryCache _cache;
        private static readonly ITranslationService _translationService;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    ApplicationConfiguration.Initialize();
                    Application.SetHighDpiMode(HighDpiMode.SystemAware);
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    //Application.Run(new frmSplashScreen(
                    //    services.GetRequiredService<ApplicationDbContext>(),
                    //   services.GetRequiredService<IMemoryCache>(),
                    //   services.GetRequiredService<ITranslationService>()
                    //   ));
                    Application.Run(new frmSplashScreen(
                     services.GetRequiredService<IDbContextFactory<ApplicationDbContext>>(),
                     services.GetRequiredService<IMemoryCache>(),
                     services.GetRequiredService<ITranslationService>()
                     ));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occured");
                }
            }
        }
        static IHostBuilder CreateHostBuilder() =>
          Host.CreateDefaultBuilder()
             .ConfigureAppConfiguration((context, config) =>
             {
                 config.SetBasePath(Directory.GetCurrentDirectory());
                 config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
             })
             .ConfigureServices((context, services) =>
             {
                 var encryptedConnectionString = context.Configuration.GetConnectionString("DefaultConnection");
                 var decryptedConnectionString = EncryptDecrypt.Decrypt(encryptedConnectionString);
                 //services.AddDbContext<ApplicationDbContext>(options =>
                 //    options.UseMySql(decryptedConnectionString, ServerVersion.AutoDetect(decryptedConnectionString),
                 //        x => x.MigrationsAssembly("HC.Migrations").EnableRetryOnFailure(0)));

                 services.AddDbContextFactory<ApplicationDbContext>(options =>
                 options.UseMySql(
                     connectionString: decryptedConnectionString,
                     serverVersion: ServerVersion.AutoDetect(decryptedConnectionString),
                     mySqlOptions => mySqlOptions.CommandTimeout(300) // Set timeout to 120 seconds
                 ));
                 services.AddMemoryCache();
                 services.AddScoped<ITranslationService, TranslationService>();
             });
    }
}
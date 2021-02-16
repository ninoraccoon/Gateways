
using Aplication;
using Aplication.Contracts;
using EntityFrameworkCore;
using Infraestructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Contracts;
using Repositories.EFRepositories;
using System.Data.Entity.Infrastructure;

namespace Gateways.Bootstrapper
{
    public static class IocRegistration
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDbContextFactory<GatewayContext>, GatewayContextFactory>();
            serviceCollection.AddSingleton<IGatewayService, GatewayService>();
            serviceCollection.AddSingleton<IGatewayRepository, GatewayRepository>();

        }
    }

    public static class AppSettingsExtensions
    {
        public static IServiceCollection AddAppSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsConfiguration = new AppSettings();
            configuration.Bind(appSettingsConfiguration);
            services.AddSingleton(appSettingsConfiguration);

            return services;
        }
    }

    public static class AppConfigurations {
        public static AppSettings GetConfiguration() {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", true, true)
               .AddJsonFile($"appsettings.{"Development"}.json", true)
               .AddEnvironmentVariables();

            var Configuration = builder.Build();
            var appSettingsConfiguration = new AppSettings();
            Configuration.Bind(appSettingsConfiguration);
            return appSettingsConfiguration;
        }
    }
}

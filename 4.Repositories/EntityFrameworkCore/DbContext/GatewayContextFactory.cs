using Infraestructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.Entity.Infrastructure;
using System.IO;

namespace EntityFrameworkCore
{
    public class GatewayContextFactory : IDbContextFactory<GatewayContext>
    {
        AppSettings _appSettings;
        

        public GatewayContextFactory()
        {
            string pathToContentRoot = Path.GetFullPath("../../../../../1.Presentation/Gateways/");
            Console.WriteLine(pathToContentRoot);
            string json = Path.Combine(pathToContentRoot, "appsettings.json");
            string jsonD = Path.Combine(pathToContentRoot, "appsettings.Development.json");
          
            var builder = new ConfigurationBuilder()
               .AddJsonFile(json, true, true)
               .AddJsonFile(jsonD, true);
            
            var Configuration = builder.Build();
            var appSettingsConfiguration = new AppSettings();
            Configuration.Bind(appSettingsConfiguration);
            Console.WriteLine(appSettingsConfiguration.ConnectionStrings.Count.ToString());
            _appSettings = appSettingsConfiguration;
        }

        public GatewayContextFactory(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public GatewayContext Create()
        {
            return new GatewayContext(_appSettings.ConnectionStrings["DefaultConnection"]);
        }

        public GatewayContext Create(string conecction)
        {
            return new GatewayContext(conecction);
        }

        public GatewayContext CreateByConfig()
        {
            return new GatewayContext(_appSettings.ConnectionStrings["DefaultConnection"]);
        }
    }
    
}

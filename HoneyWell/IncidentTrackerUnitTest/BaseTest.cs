//using Microsoft.Extensions.Configuration;

using IncidentTrackerModal;
using IncidentTrackerRepo;
using IncidentTrackerService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Service.test
{
    public class BaseTest
    {
        public static ServiceProvider serviceProvider => GetServiceProvider();

        public static ServiceProvider GetServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddOptions();
            services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
            var k = configuration.GetConnectionString("DBConnection");
            ServiceDIConfig.RegisterTypes(services);

            DIConfig.RegisterTypes(services);

            return services.BuildServiceProvider();
        }

    }
}

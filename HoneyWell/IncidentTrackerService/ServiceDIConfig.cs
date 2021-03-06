using Microsoft.Extensions.DependencyInjection;

namespace IncidentTrackerService
{
    public class ServiceDIConfig
    {
        public static void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IService, Service>();
        }
    }
}

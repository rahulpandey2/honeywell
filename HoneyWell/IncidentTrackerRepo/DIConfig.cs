using Microsoft.Extensions.DependencyInjection;

namespace IncidentTrackerRepo
{
    public class DIConfig
    {
        public static void RegisterTypes(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IIncidentTrackerContext, IncidentTrackerContext>();
        }
    }
}

using GPSApi.Database.Interfaces;
using GPSApi.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GPSApi.Database
{
    public static class ModuleDependency
    {
        public static IServiceCollection AddDatabaseModule(this IServiceCollection services)
        {
            return services.AddScoped<IPointOfInterestRepository, PointOfInterestRepository>();
        }
    }
}
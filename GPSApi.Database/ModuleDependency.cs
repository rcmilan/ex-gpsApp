using GPSApi.Database.Configuration;
using GPSApi.Database.Interfaces;
using GPSApi.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace GPSApi.Database
{
    public static class ModuleDependency
    {
        public static IServiceCollection AddDatabaseModule(this IServiceCollection services, string connectionString)
        {
            var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

            var mySqlConnection = new MySqlConnection(connectionString);

            services.AddDbContext<MyDbContext>(options => options
                    .UseMySql(mySqlConnection, serverVersion)
#if DEBUG
                    // The following three options help with debugging, but should
                    // be changed or removed for production.
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
#endif
            );

            return services.AddScoped<IPointOfInterestRepository, PointOfInterestRepository>();
        }
    }
}
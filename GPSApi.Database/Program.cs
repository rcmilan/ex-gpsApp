
using GPSApi.Database;
using Microsoft.Extensions.Hosting;

string connString = "server=localhost;port=3306;userid=mysqlusr;password=password;database=gpsdb;";

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services.AddDatabaseModule(connString))
    .Build();

await host.RunAsync();
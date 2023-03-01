using GPSApi.Database;
using Microsoft.Extensions.Hosting;

string connString = "Server=localhost; Port=3306; Database=gpsdb; Uid=mysqlusr; Pwd=password;";

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services.AddDatabaseModule(connString))
    .Build();

await host.RunAsync();
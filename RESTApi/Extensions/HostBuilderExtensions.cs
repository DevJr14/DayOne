using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace RESTApi.Extensions
{
    internal static class HostBuilderExtensions
    {
        internal static IHostBuilder UseSerilog(this IHostBuilder builder)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Log.Information("Application Starting...");
            SerilogHostBuilderExtensions.UseSerilog(builder);
            return builder;
        }
    }
}

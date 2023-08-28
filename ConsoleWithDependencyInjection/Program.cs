using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleWithDependencyInjection
{
    /// <summary>
    /// Old school. No top level statements
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Standard Main entry point
        /// </summary>
        /// <see cref="https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/main-command-line"/>
        /// <param name="args">Command line argument</param>
        static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
               .ConfigureHostConfiguration(hostConfiguration =>
               {
                   hostConfiguration.SetBasePath(Directory.GetCurrentDirectory());
                   hostConfiguration.AddJsonFile("appsettings.json");
                   hostConfiguration.AddCommandLine(args);
               })

               .ConfigureServices((hostContext, services) =>
               {
                   services.AddHostedService<ConsoleHostedService>();

               }).Build();

            host.Run();
        }
    }
}
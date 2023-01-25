using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
            var host = builder.Build();
            var config = host.Services.GetRequiredService<IConfiguration>();

            UseCredentials(config["WebCredentials:Name"]!, config["WebCredentials:Password"]!);
        }

        private static void UseCredentials(string userName, string password) =>
            Console.WriteLine($"Used credentials: {userName}, {password}");
    }
}
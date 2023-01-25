using Microsoft.Extensions.Configuration;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            var tempConfig = builder.Build();
            var fileName = tempConfig["AdditionalSettingsFile"]!;

            builder.AddJsonFile(fileName);
            var config = builder.Build();

            UseCredentials(config["WebCredentials:Name"]!, config["WebCredentials:Password"]!);

            Console.ReadLine();
        }

        private static void UseCredentials(string userName, string password) =>
            Console.WriteLine($"Used credentials: {userName}, {password}");
    }
}
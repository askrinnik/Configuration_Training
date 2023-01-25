using Microsoft.Extensions.Configuration;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings2.json", optional: true)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .AddUserSecrets<Program>()
            .AddXmlFile("XMLsettings.xml")
            .Add(new HardcodedConfigurationSource());

        var config = builder.Build();
        Console.WriteLine(config.GetDebugView());

        UseCredentials(config["WebCredentials:Name"]!, config["WebCredentials:Password"]!);
            
        Console.ReadLine();
    }

    private static void UseCredentials(string userName, string password) => 
        Console.WriteLine($"Used credentials: {userName}, {password}");
}
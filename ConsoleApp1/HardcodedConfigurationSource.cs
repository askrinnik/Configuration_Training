using Microsoft.Extensions.Configuration;

namespace ConsoleApp1
{
    public sealed class HardcodedConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder) => new HardcodedConfigurationProvider();
    }

    public sealed class HardcodedConfigurationProvider : ConfigurationProvider
    {
        public override void Load() => Set("WebCredentials:Password", "HardcodedPass");
    }
}
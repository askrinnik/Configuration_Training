using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ConfigController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly IOptions<WebCredentialsOptions> _options;

    public ConfigController(IConfiguration config, IOptions<WebCredentialsOptions> options)
    {
        _config = config;
        _options = options;
    }

    [HttpGet]
    [Route("from_configuration")]
    public WebCredentialsDto Get() => new(_config["WebCredentials:Name"]!, _config["WebCredentials:Password"]!);

    [HttpGet]
    [Route("from_options")]
    public WebCredentialsDto GetFromOptions() => 
        new(_options.Value.Name, _options.Value.Password);
}
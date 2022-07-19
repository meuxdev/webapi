using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;



[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly ILogger<HelloWorldController> _logger;

    IHelloWorldService helloWorldService;

    public HelloWorldController(ILogger<HelloWorldController> logger, IHelloWorldService helloWorldService)
    {
        _logger = logger;
        this.helloWorldService = helloWorldService;
    }

    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
}
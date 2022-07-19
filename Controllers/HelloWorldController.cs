using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;



[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly ILogger<HelloWorldController> _logger;

    private readonly IHelloWorldService _helloWorldService;

    public HelloWorldController(ILogger<HelloWorldController> logger, IHelloWorldService helloWorldService)
    {
        _logger = logger;
        _helloWorldService = helloWorldService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_helloWorldService.GetHelloWorld());
    }
}
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;



[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    private readonly ILogger<HelloWorldController> logger;

    private readonly IHelloWorldService helloWorldService;

    private readonly TareasContext dbContext;

    public HelloWorldController(ILogger<HelloWorldController> _logger, IHelloWorldService _helloWorldService, TareasContext _dbContext)
    {
        logger = _logger;
        helloWorldService = _helloWorldService;
        dbContext = _dbContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult EnsureCreated()
    {
        dbContext.Database.EnsureCreated();
        return Ok();
    }
}
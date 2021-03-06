using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;

namespace webapi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService categoryService;

    public CategoryController(ILogger<CategoryController> logger, ICategoryService _categoryService)
    {
        _logger = logger;
        categoryService = _categoryService;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(categoryService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(categoryService.GetById(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] CategoryPostDto dto)
    {

        var category = categoryService.ParseDto(dto, Guid.Empty);
        categoryService.Save(category);
        return Created("/", category);
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] CategoryPostDto dto)
    {
        var category = categoryService.ParseDto(dto, id);
        categoryService.UpdateAsync(id, category);
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoryService.DeleteAsync(id);
        return Ok("Deleted");
    }
}
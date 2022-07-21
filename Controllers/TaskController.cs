using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;
using System.Text.Json;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;

    private readonly ITaskService taskService;

    public TaskController(ILogger<TaskController> logger, ITaskService _taskService)
    {
        _logger = logger;
        taskService = _taskService;
    }


    // Get all the tasks
    [HttpGet]
    // [Route("/getall")]
    public IActionResult GetAll()
    {
        return Ok(taskService.GetAll());
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var task = await taskService.GetById(id);

        if (task == null)
        {
            return NotFound($"Product with the id {id} not founded");
        }

        var response = new ResponseDto
        {
            Message = "All good",
            Task = task,
            Status = 200
        };

        return Ok(response);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {

        Tarea? taskDeleted = await taskService.Delete(id);

        if (taskDeleted == null)
        {
            return NotFound(ResponseTaskFactory.CreateDto(404, "Task not founded!", taskDeleted));
        }

        return Ok(ResponseTaskFactory.CreateDto(200, "Deleted the task!", taskDeleted));
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] PostTaskRequestDto dto)
    {

        Tarea? taskAdded = await taskService.Save(dto);

        if (taskAdded == null)
        {
            return NotFound(ResponseTaskFactory.CreateDto(404, "Category not founded! Could not add the task.", taskAdded));
        }
        return Created("/", ResponseTaskFactory.CreateDto(201, "Task created successfully!", taskAdded));
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] PutTaskRequestDto dto)
    {

        Tarea? taskUpdated = await taskService.Update(id, dto);
        
        if(taskUpdated != null) {
            return Ok(ResponseTaskFactory.CreateDto(200, "Task updated!", taskUpdated));
        }

        return NotFound(ResponseTaskFactory.CreateDto(404, "Task Not founded!", taskUpdated));
    }


}
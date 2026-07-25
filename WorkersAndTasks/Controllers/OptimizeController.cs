using Microsoft.AspNetCore.Mvc;
using WorkersAndTasks.Models;
using WorkersAndTasks.Services;

namespace WorkersAndTasks.Controllers;

[ApiController]
[Route("[controller]")]
public class OptimizeController : ControllerBase
{
    private ISchedulerService _schedulerService;

    public OptimizeController(ISchedulerService schedulerService)
    {
        _schedulerService = schedulerService;
    }

    [HttpOptions(Name = "")]
    public IActionResult Options()
    {
        Response.Headers.Append("Allow", "OPTIONS,POST");
        return NoContent();
    }

    [HttpPost(Name = "")]
    public Schedule Optimize([FromBody] OptimizeRequest request)
    {
        return _schedulerService.GetSchedule(DateTime.Now, request.Workers, request.Tasks);
    }
}

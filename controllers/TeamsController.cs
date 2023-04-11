using Microsoft.AspNetCore.Mvc;

namespace restAPI.Controllers;

[Route(template:"api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Ok from the controller");
    }

}
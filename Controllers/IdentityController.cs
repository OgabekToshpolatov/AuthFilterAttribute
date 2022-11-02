using Microsoft.AspNetCore.Mvc;

namespace auten.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController:ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Working");
    }
}
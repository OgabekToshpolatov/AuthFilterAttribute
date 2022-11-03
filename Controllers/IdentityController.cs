using auten.Data;
using Microsoft.AspNetCore.Mvc;

namespace auten.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdentityController:ControllerBase
{
    private readonly AppDbContext _context;

    public IdentityController(AppDbContext context)
    {
        _context = context ;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Working");
    }

    [HttpPost]
    public IActionResult PostUser()
    {
        return Ok();
    }
}
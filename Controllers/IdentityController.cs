using auten.Data;
using auten.Entities;
using auten.Filters;
using auten.Models;
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
    public IActionResult Get() => Ok(_context.Users!.ToList());

    [HttpGet("lich")]
    public IActionResult GetUser()
    {
        if(!HttpContext.Request.Headers.ContainsKey("Key"))
                return Unauthorized();

         var key = HttpContext.Request.Headers["Key"].ToString();

         var user = _context.Users!.Where( x=> x.Key == key).FirstOrDefault();       

        if(user is null) return NotFound();

        return Ok(user);
    }
    
    [HttpPost]
    public IActionResult PostUser(CreateUser usermodel)
    {
        var user = new User()
        {
            Name = usermodel.Name,
            Key = Guid.NewGuid().ToString()
        };
        _context.Users!.Add(user);
        _context.SaveChanges();
        return Ok(user);
    }

    [HttpGet("calculate")]
    [TypeFilter(typeof(AuthFilterAttribute))]
    public IActionResult Calculator(int n, int k)
    {
        var a = Calculate.Calculate.Result(n,k);
        return Ok(a);
    }

     

    
     
}
using auten.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace auten.Filters;

public class AuthFilterAttribute:ActionFilterAttribute
{
    private readonly AppDbContext _context;

    public AuthFilterAttribute(AppDbContext context)
    {
        _context = context;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if(!context.HttpContext.Request.Headers.ContainsKey("Key"))
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.HttpContext.Response.WriteAsync("Unauthorized");
        }

        var key = context.HttpContext.Request.Headers["Key"].ToString();

         
        if(_context.Users!.Where(k => k.Key==key).FirstOrDefault() is null)
        {
           context.Result = new UnauthorizedResult();
        }
    }
}